using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Model;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class ApproveCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panelGridViewOfMembers.Visible = true;
            displayCustomerList();
        }
        public void displayCustomerList()
        {
            try
            {
                IMemberDao member = new MemberDao();
                List<Member> memberList = member.GetMemberListForAdmin();
                GridViewApproveCustomer.DataSource = memberList;
                GridViewApproveCustomer.DataBind();
            }
            catch (NoMemberException)
            {
               
            }

        }
        protected void gridviewApproveMember(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ApproveMember"))
            {
                IMemberDao member = new MemberDao();
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int memberId = int.Parse(GridViewApproveCustomer.Rows[rowindex].Cells[0].Text);
                member.ApproveMember(memberId, "Yes");
                Response.Write("<script> alert('"+" Approved Successfully"+"')</script>");
            }
            else if (e.CommandName.Equals("RejectMember"))
            {
                IMemberDao member = new MemberDao();
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int memberId = int.Parse(GridViewApproveCustomer.Rows[rowindex].Cells[0].Text);
                member.ApproveMember(memberId, "No");
                Response.Write("<script> alert('" + " Rejected Successfully" + "')</script>");
            }
            displayCustomerList();
        }

        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}