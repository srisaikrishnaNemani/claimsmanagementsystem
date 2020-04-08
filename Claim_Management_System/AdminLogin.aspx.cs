using System;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            IAdminDao adminDao = new AdminDao();
            int status = adminDao.LoginAdmin(username, password);
            //int status =2;
            if (username == "SuperUser" && password == "SuperUser")
            {
                Session["username"] = username;
                Session["type"] = "SuperUser";

                Response.Redirect("SuperUserHomePage.aspx");
            }
            else if (status == 1)
            {
                Session["username"] = username;
                Session["type"] = "Admin";
                Response.Redirect("AdminHomePage.aspx");
            }
            else if (status == 2)
            {
                lblAlert.Text = "You login is not accepted by admin";
                Response.Redirect("RejectionPage.aspx");
            }
            else if (status == 3)
            {
                lblAlert.Text = "You are not active ! please wait for sometime";
            }
            else if (status == 0)
            {
                lblAlert.Text = "Please check the credentials. If not registered, please register";
            }
        }
    }
}