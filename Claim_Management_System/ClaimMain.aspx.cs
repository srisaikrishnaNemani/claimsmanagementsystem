using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace Claim_Management_System
{
    public partial class ClaimMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DisplayDataClaim();
                }
                catch (NoMemberPlanException)
                {
                    Response.Write("<script>alert('No Member Plan')</script>");
                }
            }
        }
        protected void gridPolicy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ClaimButton"))
            {
                Claim_Management_Model.Claim claim = new Claim_Management_Model.Claim();
                int rowindex = int.Parse(e.CommandArgument.ToString());
                string cmId = gridPolicy.Rows[rowindex].Cells[0].Text;
                claim.ClaimId = int.Parse(cmId);
                claim.MemberId = Session["username"].ToString();
                claim.PlanName = gridPolicy.Rows[rowindex].Cells[1].Text;
                claim.PlanCode =int.Parse ( gridPolicy.Rows[rowindex].Cells[0].Text);
                claim.ClaimServiceDate = DateTime.Parse(gridPolicy.Rows[rowindex].Cells[4].Text);
                claim.ClaimSubmissionDate = DateTime.Now.AddDays(10);
                claim.ClaimProcessingDate = DateTime.Now;
                claim.ClaimStatus = "Processing";
                claim.ClaimAmount = long.Parse(gridPolicy.Rows[rowindex].Cells[3].Text);
                IClaimDao claimDao = new ClaimDao();
                claimDao.RequestClaim(claim);
                PlanCode pland = new PlanCode();
                string name = pland.PlanName;
                Response.Redirect($"Claim.aspx?name={name}");
            }
        }
        protected void DisplayDataClaim()
        {
            try
            {
                IMemberPlanDao member = new MemberPlanDao();
                List<MemberPlan> plan = member.GetMemberPlanForId(Session["username"].ToString());
                gridPolicy.DataSource = plan;
                gridPolicy.DataBind();
            }
            catch (NoMemberException)
            {
                Response.Write("<script>alert('No member plan avilable')</script>");
            }
        }

        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberHomePage.aspx");
        }
    }
}