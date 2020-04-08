using Claim_Management_Model;
using System.Collections.Generic;

namespace Claim_Management_Dao
{
    public interface IPlanCodeDao
    {
        int AddPlan(PlanCode planCode);
        int EditPlan(PlanCode planCode);
        int RemovePlan(int planCodeId);
        List<PlanCode> ViewPlan();
    }
}
