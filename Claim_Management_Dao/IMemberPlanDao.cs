using Claim_Management_Model;
using System.Collections.Generic;

namespace Claim_Management_Dao
{
    public interface IMemberPlanDao
    {
        int AddMemberPlan(MemberPlan memberPlan);
        List<MemberPlan> GetMemberPlan();
        int GetMemberPlanId(int memberId, int PlanId);
        List<MemberPlan> GetMemberPlanForIdWhereNoClaim(string memberId);
        List<MemberPlan> GetMemberPlanForId(string memberId);
    }
}
