using System;

namespace Claim_Management_System
{
    public partial class MemberHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] != null)
            {
                if (Session["type"].ToString() != "User")
                {
                    Response.Redirect("MemberLogin.aspx");
                }
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ClaimMain.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Policies.aspx");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TrackPolicy.aspx");
        }
    }
}