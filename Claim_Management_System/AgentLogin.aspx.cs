using System;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class Agent : System.Web.UI.Page
    {
        public string LastName { get; internal set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            IAgentDao adminDao = new AgentDao();
            int status = adminDao.LoginAgent(username, password);
            //int status =2;
            if (status == 1)
            {
                Session["username"] = username;
                Session["type"] = "User";
                Response.Redirect("AgentHomePage.aspx");
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
 
