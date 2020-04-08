using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class TrackPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayClaimStatus();
                DisplayReSubmitClaims();
            }
        }
        protected void DisplayClaimStatus()
        {
            try
            {
                IMemberDao member = new MemberDao();
                List<Claim_Management_Model.Claim> claimStatus = member.ClaimStatus(Session["username"].ToString());
                gridClaimStatus.DataSource = claimStatus;
                gridClaimStatus.DataBind();
            }
            catch (Exception)
            {
                lblApproveOrProcessing.Visible = true;
            }
        }
        public void DisplayReSubmitClaims()
        {
            try
            {
                IMemberDao memberDao = new MemberDao();
                List<Claim_Management_Model.Claim> resubmitList = memberDao.ClaimStatusRejected(Session["username"].ToString());
                gridReSubmitClaims.DataSource = resubmitList;
                gridReSubmitClaims.DataBind();
            }
            catch (Exception)
            {
                lblReSubmit.Visible = true;
            }
        }
        protected void ResubmitGridview(object sender, GridViewCommandEventArgs e)
        {
           Claim_Management_Model . Claim getid = new Claim_Management_Model.Claim();
            int rowindex = int.Parse(e.CommandArgument.ToString());
            int claimid = Convert.ToInt32(gridReSubmitClaims.Rows[rowindex].Cells[0].Text);
            
            int result = new ClaimDao().ResubmitClaim(claimid);
            if (result == 1)
            {
                Response.Write("<script>alert('" + "Claim is Submitted " + "')</script>");
                Response.Redirect("TrackPolicy.aspx");
            }
            else
            {
                Response.Write("<script>alert('" + "Claim is not Submitted " + "')</script>");
                Response.Redirect("TrackPolicy.aspx");
            }
        }
        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberHomePage.aspx");
        }
    }
}