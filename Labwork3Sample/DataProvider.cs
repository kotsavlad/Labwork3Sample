using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Labwork3Sample
{
    public static class DataProvider
    {
        public class Patient
        {
            //public int Id { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
        }

        public class Doctor
        {
            //public int Id { get; set; }
            public string Name { get; set; }
            public string Speciality { get; set; }

        }

        public class Visit
        {
            public int PatientId { get; set; }
            public int DoctorId { get; set; }
            public DateTime? Date { get; set; }
        }

        public static Dictionary<int, Patient> Patients { get; private set; }
        public static Dictionary<int, Doctor> Doctors { get; private set; }
        public static List<Visit> Visits { get; private set; }


        public static void ReadData(string DataDir)
        {
            Patients = new Dictionary<int, Patient>();
            Doctors = new Dictionary<int, Doctor>();
            Visits = new List<Visit>();
            foreach (var line in File.ReadAllLines(DataDir + "Doctors_ansi.txt", Encoding.GetEncoding(1251)))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length != 3 || !int.TryParse(words[0], out int id))
                    continue;
                Doctors.Add(id, new Doctor { Name = words[1], Speciality = words[2] });
            }

            foreach (var line in File.ReadAllLines(DataDir + "patients.txt"))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length != 3 || !int.TryParse(words[0], out int id))
                    continue;
                Patients.Add(id, new Patient { Name = words[1], BirthDate = DateTime.Parse(words[2]) });
            }

            foreach (var line in File.ReadAllLines(DataDir + "Visits_missing.txt"))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length < 2 || !int.TryParse(words[0], out int id))
                    continue;
                Visits.Add(new Visit
                {
                    DoctorId = id,
                    PatientId = int.Parse(words[1]),
                    Date = words.Length == 3? DateTime.Parse(words[2]) : null,
                });
            }
        }
    }
}