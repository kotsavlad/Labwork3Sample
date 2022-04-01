using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using static Labwork3Sample.DataProvider;

namespace Labwork3Sample
{
    public partial class MainPage : Page
    {
        private SortedSet<int> years;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            if (!(IsPostBack || IsCrossPagePostBack))
            // IsCrossPagePostBack is used to avoid redundant load of the data through transferring from ResultPage1 to MainPage
            // Alternative without set of PostBackUrl property of Task1Button:
            //if (!(IsPostBack || (PreviousPage != null && PreviousPage.PreviousPage == this)))
            // This work also for ResultPage2 unlike first solution (because Task2Button.PostBackUrl is empty):
            {
                var DataDir = Server.MapPath(@"~/App_Data/");
                //const string DataDir = @"c:\Programs\SampleData\";
                ReadData(DataDir);
                DoctorsGridView.DataSource = Doctors.Values
                    .Select(d => new { Лікар = d.Name, Спеціалізація = d.Speciality });
                DoctorsGridView.DataBind();
                PatientsGridView.DataSource = Patients.Values
                    .Select(p => new { Пацієнт = p.Name, Народження = p.BirthDate.ToShortDateString() });
                PatientsGridView.DataBind();

                //VisitsGridView.DataSource = Visits;
                var visits = Visits.Select(v => new
                {
                    Patient = Patients[v.PatientId].Name,
                    Doctor = Doctors[v.DoctorId].Name,
                    //Date = v.Date?.ToShortDateString() ?? "----------------",
                    Date = v.Date?.ToShortDateString()
                });
                VisitsGridView.DataSource = visits
                    .OrderBy(v => (v.Patient, v.Doctor))
                    .Select(v => new { Пацієнт = v.Patient, Лікар = v.Doctor, Дата = v.Date });
                VisitsGridView.DataBind();

                years = new SortedSet<int>();
                foreach (var visit in Visits)
                {
                    if (visit.Date.HasValue)
                        years.Add(visit.Date.Value.Year);
                }
                foreach (var year in years)
                {
                    YearsDropDown.Items.Add(year.ToString());
                }
                YearsDropDown.Items.Add("Усі роки");
            }
        }

        protected void Task2Button_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<int, HashSet<string>>();

            foreach (var visit in Visits)
            {
                if (!dict.ContainsKey(visit.PatientId))
                    dict.Add(visit.PatientId, new HashSet<string>());
                dict[visit.PatientId].Add(Doctors[visit.DoctorId].Speciality);
            }

            var allCount = Doctors.Values.Select(d => d.Speciality).Distinct().Count();
            var patientList = new List<string>();
            foreach (var pair in dict)
            {
                if (pair.Value.Count == allCount)
                {
                    patientList.Add(Patients[pair.Key].Name);
                }
            }
            Session["patientList"] = patientList;
            Server.Transfer("ResultPage2.aspx");
        }
    }
}
