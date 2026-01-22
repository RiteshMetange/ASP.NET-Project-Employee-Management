using System;

namespace EmployeeManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                Session["User"] = "admin";
                Session.Timeout = 1; // 1 minute inactivity (change as needed)

                Response.Redirect("Studentform.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password";
            }
        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
