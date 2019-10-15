using System;
using System.Collections.Generic;
using System.Text;

namespace EnrolleeSplitter
{
    public class Enrollee
    {
        public Enrollee(string line)
        {
            var fields = line.Split('\t');

            this.UserId = fields[0];
            this.FirstName = fields[1];
            this.LastName = fields[2];
            this.Version = int.Parse(fields[3]);
            this.Insurer = fields[4];
        }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
        public string Insurer { get; set; }

        public string ToCsv()
        {
            return $"{this.UserId}\t{this.FirstName}\t{this.LastName}\t{this.Version}\t{this.Insurer}";
        }
    }
}
