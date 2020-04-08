using System;

namespace Claim_Management_System
{
    public partial class AfterLoginHomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() != null)
                {
                    lblWelcome.Text = Session["username"].ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("HomePage.aspx");
        }
    }
}