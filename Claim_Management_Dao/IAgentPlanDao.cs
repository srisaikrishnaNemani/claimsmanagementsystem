using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claim_Management_Model;



namespace Claim_Management_Dao
{

    public interface IAgentPlanDao
    {
        int AddAgentPlan(AgentPlan AgentPlan);
        List<AgentPlan> GetAgentPlan();
        int GetAgentPlanId(int AgentId, int PlanId);
        List<AgentPlan> GetAgentPlanForIdWhereNoClaim(string AgentId);
        List<AgentPlan> GetAgentPlanForId(string AgentId);
    }
}

