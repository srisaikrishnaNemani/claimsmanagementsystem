using System;

namespace Claim_Management_System
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] != null)
            {
                if (Session["type"].ToString() != "Admin")
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
          
        }      
        protected void btnApproveCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveCustomer.aspx");
        }

        protected void btnApproveClaims_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveClaims.aspx");
        }

        protected void btnAddEdit_Click(object sender, EventArgs e)
        {
             Response.Redirect("Policy.aspx");
        }
    }
}