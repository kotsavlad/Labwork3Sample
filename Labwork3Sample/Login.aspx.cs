using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly Dictionary<string, string> users = new()
        {
            { "user1", "password1" },
            { "admin", "admin_pass" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var userName = UserTextBox.Text;
            var password = PasswordTextBox.Text;
            if (users.Contains(new KeyValuePair<string, string>(userName, password)))
            {
                Session["user"] = userName;
                Response.Redirect("MainPage.aspx");
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
        }
    }
}