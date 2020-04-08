using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace Claim_Management_System
{
    public partial class Policies : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            lblmemberId.Text = Session["Username"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelViewPolicy.Visible = true;
                displayPlan();
            }
        }

        public void displayPlan()
        {
            try
            {
                PlanCodeDao planCode = new PlanCodeDao();
                List<PlanCode> planCodeList = planCode.ViewPlan();
                List<int> planIdList = new List<int>();

                if (planCodeList.Count == 0)
                {
                    panelViewPolicy.Visible = false;
                }
                else
                {
                    gridViewPlan.DataSource = planCodeList;
                    gridViewPlan.DataBind();
                }
            }
            catch (NoMemberPlanException)
            {
                PlanCodeDao planCode = new PlanCodeDao();
                List<PlanCode> planCodeList = planCode.ViewPlan();
                gridViewPlan.DataSource = planCodeList;
                gridViewPlan.DataBind();
            }
        }
        protected void JoinPolicy(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Join"))
            {
                IMemberPlanDao memberPlanDao = new MemberPlanDao();
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int planCodeId = int.Parse(gridViewPlan.Rows[rowindex].Cells[0].Text);

                DropDownList ddl = (DropDownList)gridViewPlan.Rows[rowindex].FindControl("ddlCoverage"); //ddlCoverage
                string SelectedCoverageText = ddl.SelectedItem.ToString();
                int coverageNumber = int.Parse(SelectedCoverageText.Substring(SelectedCoverageText.Length - 1, 1));

                DateTime startDat = DateTime.Now;
                DateTime endDat = DateTime.Parse("01/01/2021");
                long coverageAmount = 0;
                switch (coverageNumber)
                {
                    case 1:
                        endDat = startDat.AddMonths(3);
                        coverageAmount = Convert.ToInt64(gridViewPlan.Rows[rowindex].Cells[3].Text);
                        break;
                    case 2:
                        endDat = startDat.AddMonths(6);
                        coverageAmount = Convert.ToInt64(gridViewPlan.Rows[rowindex].Cells[4].Text);
                        break;
                    case 3:
                        endDat = startDat.AddMonths(9);
                        coverageAmount = Convert.ToInt64(gridViewPlan.Rows[rowindex].Cells[5].Text);
                        break;
                    case 4:
                        endDat = startDat.AddMonths(12);
                        coverageAmount = Convert.ToInt64(gridViewPlan.Rows[rowindex].Cells[6].Text);
                        break;
                    case 5:
                        endDat = startDat.AddMonths(15);
                        coverageAmount = Convert.ToInt64(gridViewPlan.Rows[rowindex].Cells[7].Text);
                        break;
                }
                MemberPlan memberPlan = new MemberPlan(0, lblmemberId.Text, planCodeId, startDat, endDat, coverageAmount, coverageNumber);
                memberPlanDao.AddMemberPlan(memberPlan);
                displayPlan();
                Response.Write("<script>alert('" + "Joined Policy" + "')</script>");
            }
        }

        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberHomePage.aspx");
        }
    }
}