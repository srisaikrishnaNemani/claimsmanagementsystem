using System.Configuration;

namespace Claim_Management_Dao
{
    public class Helper
    {
        static public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ClaimsManagementSystem"].ConnectionString;
            }
        }
    }
}
