using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private const string doctorsFileName = "Doctors_ansi.txt";
        private const string patientsFileName = "Patients.txt";
        private const string visitsFileName = "Visits.txt";


        public static void ReadData(string DataDir)
        {
            Patients = new Dictionary<int, Patient>();
            Doctors = new Dictionary<int, Doctor>();
            Visits = new List<Visit>();
            Trace.Listeners.Add(new TextWriterTraceListener(DataDir + "trace.log"));
            Trace.AutoFlush = true;
            Trace.WriteLine(DateTime.Now.ToString());
            Trace.Indent();
            int lineNumber = 0;
            var fileName = DataDir + doctorsFileName;
            foreach (var line in File.ReadAllLines(fileName, Encoding.GetEncoding(1251)))
            {
                lineNumber++;
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length != 3 || !int.TryParse(words[0], out int id))
                {
                    Trace.WriteLine($"{fileName}: unconsistent data in line #{lineNumber}");
                    continue;
                }
                Doctors.Add(id, new Doctor { Name = words[1], Speciality = words[2] });
            }

            lineNumber = 0;
            fileName = DataDir + patientsFileName;
            foreach (var line in File.ReadAllLines(DataDir + "patients.txt"))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length != 3 || !int.TryParse(words[0], out int id) || !DateTime.TryParse(words[2], out var birthDate))
                {
                    Trace.WriteLine($"{fileName}: unconsistent data in line #{lineNumber}");
                    continue;
                }
                Patients.Add(id, new Patient { Name = words[1], BirthDate = birthDate });
            }

            lineNumber = 0;
            fileName = DataDir + patientsFileName;
            foreach (var line in File.ReadAllLines(DataDir + "Visits_missing.txt"))
            {
                var words = Regex.Split(line.Trim(), @"\s+");
                if (words.Length < 2 || !int.TryParse(words[0], out int doctorId) || !Doctors.ContainsKey(doctorId) ||
                    !int.TryParse(words[1], out int patientId) || !Patients.ContainsKey(patientId))
                {
                    Trace.WriteLine($"{fileName}: unconsistent data in line #{lineNumber}");
                    continue;
                }
                try
                {
                    Visits.Add(new Visit
                    {
                        DoctorId = doctorId,
                        PatientId = patientId,
                        Date = words.Length == 3 ? DateTime.Parse(words[2]) : null,
                    });
                }
                catch (FormatException)
                {
                    Trace.WriteLine($"{fileName}: unconsistent data in line #{lineNumber}");
                    continue;
                }
            }
            Trace.Unindent();
        }
    }
}