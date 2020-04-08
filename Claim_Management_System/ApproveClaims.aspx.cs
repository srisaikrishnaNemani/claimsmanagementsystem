using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class ApproveClaims : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelGridViewOfClaim.Visible = true;
                DisplayDataClaimApprove();
            }
        }

        protected void DisplayDataClaimApprove()
        {
            try
            {
                IClaimDao claim = new ClaimDao();
                List<Claim_Management_Model.Claim> claimList = claim.ViewClaimForAdmin();
                gridViewApproveClaims.DataSource = claimList;
                gridViewApproveClaims.DataBind();
            }
            catch (NoClaimException)
            {
                gridViewApproveClaims.Visible = false;
                panelNoClaim.Visible = true;
            }
        }
        protected void ApproveClaim(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("ApproveClaim"))
            {
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int claimId = int.Parse(gridViewApproveClaims.Rows[rowindex].Cells[0].Text);
                Session["Message"] = "Approve";
                Response.Redirect("ClaimApproval.aspx?ClaimId=" + claimId);
            }
            if (e.CommandName.Equals("RejectClaim"))
            {
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int claimId = int.Parse(gridViewApproveClaims.Rows[rowindex].Cells[0].Text);
                Session["Message"] = "reject";
                Response.Redirect("ClaimApproval.aspx?ClaimId=" + claimId);
            }
        }

        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}