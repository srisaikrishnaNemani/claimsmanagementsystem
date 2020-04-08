using System;
using Claim_Management_Dao;

namespace Claim_Management_System
{
    public partial class ForgotPasswordMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            IMemberDao member = new MemberDao();
            string EmailId = txtEmailId.Text;
            string FavoritePerson = txtFavPerson.Text;
            string Password = txtPassword.Text;
            string ConfPassword = txtConfPassword.Text;
            int result = member.SecurityMember(EmailId, FavoritePerson, Password, ConfPassword);
            if (result == 1)
            {
                Response.Write("<script>alert('" + "Password Changed Successfully " + "')</script>");
            }
            else
            {
                Response.Write("<script>alert('" + "Details Not Found " + "')</script>");
            }
        }
    }
}