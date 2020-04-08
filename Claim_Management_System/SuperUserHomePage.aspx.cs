using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace Claim_Management_System
{
    public partial class SuperUserHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] != null)
            {
                if (Session["type"].ToString() != "SuperUser")
                {
                    Response.Redirect("AdminHomePage.aspx");
                }
            }
            if (!IsPostBack)
            {
                PanelNotification.Visible = false;
                PanelGridView.Visible = false;
                DisplayData();
            }
        }
        protected void DisplayData()
        {
            try
            {
                PanelNotification.Visible = false;
                PanelGridView.Visible = true;
                AdminDao Admin = new AdminDao();
                List<Admin> adminList = Admin.GetAdminListForSuperUser();
                gridSuperUser.DataSource = adminList;
                gridSuperUser.DataBind();

            }
            catch (Exception)
            {
                PanelNotification.Visible = true;
                PanelGridView.Visible = false;
            }
        }

        protected void gridSuperUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ApproveAdmin"))
            {
                IAdminDao admin = new AdminDao();
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int adminId = int.Parse(gridSuperUser.Rows[rowindex].Cells[0].Text);
                admin.ApproveAdmin(adminId, "Yes");

            }
            else if (e.CommandName.Equals("RejectAdmin"))
            {
                IAdminDao admin = new AdminDao();
                int rowindex = int.Parse(e.CommandArgument.ToString());
                int adminId = int.Parse(gridSuperUser.Rows[rowindex].Cells[0].Text);
                admin.ApproveAdmin(adminId, "No");
            }
            DisplayData();
        }
    }
}