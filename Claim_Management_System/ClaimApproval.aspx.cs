using System;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class ClaimApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["type"] != null)
                {
                    if (Session["type"].ToString() != "Admin")
                    {
                        Response.Redirect("AdminLogin.aspx");
                    }
                }
                if (Session["Message"].ToString() == "Approve")
                {
                    regApprove.Visible = true;
                    int claimId = int.Parse(Request.QueryString["ClaimId"].ToString());
                    IClaimDao claimDao = new ClaimDao();
                    Claim_Management_Model.Member memName =new Claim_Management_Model.Member();
                    Claim_Management_Model.Claim claim = claimDao.ViewClaimById(claimId);
                    lblMemberName.Text = memName.FirstName;
                    lblPlanName.Text = claim.PlanName ;
                    lblClaimServiceDate.Text = claim.ClaimServiceDate.ToString("dd/MM/yyyy");
                    lblClaimSubmissionDate.Text = claim.ClaimSubmissionDate.ToString("dd/MM/yyyy");
                    lblClaimAmount.Text = claim.ClaimAmount.ToString();
                    lblMessage.Text = "Amount To Approve";
                    btnReject.Visible = false;
                }
                else
                {
                    int claimId = int.Parse(Request.QueryString["ClaimId"].ToString());
                    IClaimDao claimDao = new ClaimDao();
                    Claim_Management_Model.Claim claim = claimDao.ViewClaimById(claimId);
                    lblMemberName.Text = claim.FirstName;
                    lblPlanName.Text = claim.PlanName;
                    lblClaimServiceDate.Text = claim.ClaimServiceDate.ToString("dd/MM/yyyy");
                    lblClaimSubmissionDate.Text = claim.ClaimSubmissionDate.ToString("dd/MM/yyyy");
                    lblClaimAmount.Text = claim.ClaimAmount.ToString();
                    lblMessage.Text = "Reason For Rejection";
                    btnApprove.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int claimId = int.Parse(Request.QueryString["ClaimId"].ToString());

                IClaimDao claimDao = new ClaimDao();
                claimDao.ApproveClaim(claimId, "Approved", long.Parse(txtAmounApprove.Text));
                Response.Write("<script>alert('" + "Claim Approved" + "');window.location.href='ApproveClaims.aspx';</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('" + "something goes wrong try again !" + "');window.location.href='ApproveClaims.aspx';</script>");
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                int claimId = int.Parse(Request.QueryString["ClaimId"].ToString());
                IClaimDao claimDao = new ClaimDao();
                // string reason = "Rejected - " + txtAmounApprove.Text.ToString();
                claimDao.ApproveClaim(claimId, "Rejected", 0);
                Response.Write("<script>alert('" + "Claim Rejected" + "');window.location.href='ApproveClaims.aspx';</script>");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('" + "something goes wrong try again !" + "');window.location.href='ApproveClaims.aspx';</script>");
            }
        }
    }
}