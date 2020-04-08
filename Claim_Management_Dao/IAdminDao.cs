using Claim_Management_Model;
using System.Collections.Generic;

namespace Claim_Management_Dao
{
    public interface IAdminDao
    {
        int RegisterAdmin(Admin admin);
        int LoginAdmin(string emailId, string password);
        List<Admin> GetAdminListForSuperUser();
        int ApproveAdmin(int adminId, string active);
        int SecurityAdmin(string EmailId, string FavoritePerson, string Password, string ConfPassword);
    }
}
