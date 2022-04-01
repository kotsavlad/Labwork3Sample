using System;
using System.Collections.Generic;
using System.Linq;
using static Labwork3Sample.DataProvider;

namespace Labwork3Sample
{
    public partial class ResultPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage is not null && Session["years"] is not null)
            {
                var year = (HashSet<int>)(Session["years"]);
                var dict = new Dictionary<int, DateTime>();
                foreach (var visit in Visits)
                {
                    if (!(visit.Date.HasValue && year.Contains(visit.Date.Value.Year)))
                        continue;
                    if (!dict.ContainsKey(visit.DoctorId) ||
                        dict[visit.DoctorId] > Patients[visit.PatientId].BirthDate)
                        dict[visit.DoctorId] = Patients[visit.PatientId].BirthDate;
                }
                if (dict.Count > 0)
                {
                    ResultGrid.DataSource = dict.Select(pair => new
                    {
                        Лікар = Doctors[pair.Key].Name,
                        Вік = DateTime.Now.DayOfYear > pair.Value.DayOfYear ?
                        DateTime.Now.Year - pair.Value.Year : DateTime.Now.Year - pair.Value.Year - 1
                    });
                    ResultGrid.DataBind();
                    ResultGrid.Visible = true;
                }
                else
                {
                    ResultLabel.Text = $"Немає даних про прийоми у {year} році.";
                    ResultGrid.Visible = false;
                }
            }
            else
                Response.Redirect("MainPage.aspx");
        }
    }
}