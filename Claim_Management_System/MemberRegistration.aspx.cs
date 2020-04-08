using System;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace Claim_Management_System
{
    public partial class MemberRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdminSignup_Click(object sender, EventArgs e)
        {
            Member member = new Member();

            member.FirstName = txtFirstName.Text;
            member.LastName = txtLastName.Text;
            member.DateOfBirth = DateTime.Parse(txtDob.Text);
            if (rdMale.Checked)
                member.Gender = "Male";
            else
                member.Gender = "female";
            member.Age = int.Parse(txtAge.Text);
            member.Contact = long.Parse(txtContactNumber.Text);
            member.AltContact = long.Parse(txtAltContactNumber.Text);
            member.EmailId = txtEmail.Text;
            member.Password = txtPassword.Text;
            member.ConfirmPassword = txtConfirmPassword.Text;
            member.AddrsLine1 = txtAds1.Text;
            member.AddrsLine2 = txtAds2.Text;
            member.City = txtCity.Text;
            member.State = txtState.Text;
            member.ZipCode = int.Parse(txtZipCode.Text);
            member.Active = "processing";
            member.FavoritePerson = FavPerson.Text;

            IMemberDao memberdao = new MemberDao();

            int num;
            num = memberdao.RegisterMember(member);
            if (num == 1)
            {
                Response.Redirect("Successpage.aspx");
            }
        }
    }
}