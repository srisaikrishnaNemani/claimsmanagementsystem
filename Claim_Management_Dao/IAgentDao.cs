using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claim_Management_Model;


namespace Claim_Management_Dao
{
    public interface IAgentDao
    {

        int RegisterAgent(Agent member);
        int LoginAgent(string emailId, string password);
        List<Agent> GetAgentListForAdmin();
        int ApproveAgent(int AgentId, string active);
        List<Claim> ClaimStatus(string AgentId);
        List<Claim> ClaimStatusRejected(string ClaimId);
        int SecurityMember(string EmailId, string FavoritePerson, string Password, string ConfPassword);

    }
}
