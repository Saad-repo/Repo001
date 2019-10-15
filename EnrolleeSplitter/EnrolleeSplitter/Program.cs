using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EnrolleeSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enrollee Files Splitter\r\n");

            var currFileName = string.Empty;
            var currLineNum = 1;

            if (args.Length == 0)
            {
                args = new string[] { Directory.GetCurrentDirectory() };
            }

            try
            {
                if (Directory.Exists(args[0]))
                {
                    // get & load enrollees
                    LoadEnrollees(ref currFileName, ref currLineNum, args);

                    // list insurers
                    CreateInsurerFiles();
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", args[0]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Last File Name: {currFileName}\r\nFailed Line#: {currLineNum}");
            }        
        }

        /// <summary>
        ///     Creates output files
        /// </summary>
        private static void CreateInsurerFiles()
        {
            foreach (var insurer in Repo.Insurers)
            {
                var enrolleesOrdered = insurer.Value.OrderBy(e => e.Value.LastName);
                StringBuilder sb = new StringBuilder();

                foreach (var enrollee in enrolleesOrdered)
                {
                    sb.AppendLine(enrollee.Value.ToCsv());
                }

                using (StreamWriter sw = new StreamWriter($"output_{insurer.Key}.txt", true))
                {
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        /// <summary>
        ///     Load enrollee records from input files
        /// </summary>
        /// <param name="currFileName">Current File Name</param>
        /// <param name="currLineNum">Current line number</param>
        /// <param name="args">args</param>
        private static void LoadEnrollees(ref string currFileName, ref int currLineNum, string[] args)
        {
            var files = Directory.GetFiles(args[0], "*.csv");

            foreach (var file in files)
            {
                currFileName = file;
                currLineNum = 1;

                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        currLineNum++;
                        Repo.AddEnrollee(line);
                    }
                }
            }
        }
    }
}
