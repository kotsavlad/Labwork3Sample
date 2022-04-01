using System;
using System.Collections.Generic;

namespace Labwork3Sample
{
    public partial class ResultPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage is null || Session["patientList"] is null)
            {
                Response.Redirect("MainPage.aspx");
            }
            var patients = (List<string>)Session["patientList"];
            if (patients.Count == 0)
            {
                ResultLabel.Text = "Немає пацієнтів, які були на прийомі у лікарів всіх спеціальностей.";
                ResultListBox.Visible = false;
            }
            else
            {
                ResultLabel.Text = "Пацієнти";
                foreach (var item in patients)
                {
                    ResultListBox.Items.Add(item);
                }
                ResultListBox.Visible = true;
            }
        }
    }
}