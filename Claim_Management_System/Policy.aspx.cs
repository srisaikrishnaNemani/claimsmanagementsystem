using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace Claim_Management_System
{
    public partial class Policy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelAddPlan.Visible = true;
            EditPlanShowData();
        }

        protected void gridPlan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int planId = int.Parse(gridPlan.Rows[e.RowIndex].Cells[0].Text);
                IPlanCodeDao planDao = new PlanCodeDao();
                planDao.RemovePlan(planId);
                Response.Write("<script>alert('" + "Policy removed succesfully" + "')</script>");

                EditPlanShowData();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('" + "This policy is currently consumed by customers. Please try again once it expires " + "')</script>");
            }
        }
        protected void EditPlanShowData()
        {
            try
            {
                IPlanCodeDao pDao = new PlanCodeDao();
                List<PlanCode> dt = pDao.ViewPlan();
                gridPlan.DataSource = dt;
                gridPlan.DataBind();
            }
            catch (NoPlanException)
            {
                Response.Write("<script>alert('" + "No policies to Show" + "')</script>");
            }
        }
        protected void gridPlan_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            EditPlanShowData();
        }

        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            PlanCode plan = new PlanCode();
            plan.PlanName = txtPlanName.Text;
            plan.PlanDescription = txtPlainDescription.Text;
            plan.Coverage1 = long.Parse(txtCoverage1.Text);
            plan.Coverage2 = long.Parse(txtCoverage2.Text);
            plan.Coverage3 = long.Parse(txtCoverage3.Text);
            plan.Coverage4 = long.Parse(txtCoverage4.Text);
            plan.Coverage5 = long.Parse(txtCoverage5.Text);
            IPlanCodeDao plandao = new PlanCodeDao();
            int planee = plandao.AddPlan(plan);
            if (planee == 1)
            {
                Response.Redirect("Policy.aspx");
            }
        }
    }
}