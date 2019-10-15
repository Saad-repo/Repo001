using System;
using System.Collections.Generic;
using System.Text;

namespace EnrolleeSplitter
{
    /// <summary>
    ///     Repository of Enrollees
    /// </summary>
    public static class Repo
    {
        private static Dictionary<string, Dictionary<string, Enrollee>> insurers = new Dictionary<string, Dictionary<string, Enrollee>>();
        private static Dictionary<string, Enrollee> enrollees = new Dictionary<string, Enrollee>();

        public static Dictionary<string, Enrollee> Enrolles => enrollees;
        public static Dictionary<string, Dictionary<string, Enrollee>> Insurers => insurers;

        public static void AddEnrollee(string line)
        {
            var enrollee = new Enrollee(line);

            if(Insurers.ContainsKey(enrollee.Insurer))
            {
                if (Insurers[enrollee.Insurer].ContainsKey(enrollee.UserId))
                {
                    var matchingEnrollee = Insurers[enrollee.Insurer][enrollee.UserId];

                    if (enrollee.Version > matchingEnrollee.Version)
                    {
                        Insurers[enrollee.Insurer].Remove(matchingEnrollee.UserId);
                        Insurers[enrollee.Insurer].Add(enrollee.UserId, enrollee);
                    }
                }
                else
                {
                    Insurers[enrollee.Insurer].Add(enrollee.UserId, enrollee);
                }
            }
            else
            {
                var newEnrolleeCollection = new Dictionary<string, Enrollee>()
                {
                    { enrollee.UserId, enrollee }
                };

                Insurers.Add(enrollee.Insurer, newEnrolleeCollection);
            }
        }
    }
}
