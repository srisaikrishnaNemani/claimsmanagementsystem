using System;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace Claim_Management_System
{
    public partial class AdminRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminSignup_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();

            admin.FirstName = txtFirstName.Text;
            admin.LastName = txtLastName.Text;
            admin.DateOfBirth = DateTime.Parse(txtDob.Text);
            if (rdMale.Checked)
                admin.Gender = "Male";
            else
                admin.Gender = "female";
            admin.Age = int.Parse(txtAge.Text);
            admin.Contact = long.Parse(txtContactNumber.Text);
            admin.AltContact = long.Parse(txtAltContactNumber.Text);
            admin.EmailId = txtEmail.Text;
            admin.Password = txtPassword.Text;
            admin.ConfirmPassword = txtConfirmPassword.Text;
            admin.Active = "processing";
            admin.Favoriteperson = FavPerson.Text;

            IAdminDao admindao = new AdminDao();

            int num;
            num = admindao.RegisterAdmin(admin);
            if (num == 1)
            {
                Response.Redirect("Successpage.aspx");
            }
        }
    }
}
