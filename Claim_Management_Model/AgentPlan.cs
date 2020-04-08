using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Management_Model
{
   public  class AgentPlan : PlanCode
    {
        private int _AgentPlanId;
        private string _AgentId;
        private int planCodeId;
        private DateTime _startDate;
        private DateTime _endDate;
        private long _coverageAmount;
        private int _coverageNumber;

        public AgentPlan()
        {

        }

        public AgentPlan(int _AgentPlanId, string _AgentId, int planCodeId, DateTime _startDate, DateTime _endDate, long _coverageAmount, int _coverageNumber)
        {
            this.AgentPlanId = _AgentPlanId;
            this.AgentId = _AgentId;
            this.PlanCodeId = planCodeId;
            this.StartDate = _startDate;
            this.EndDate = _endDate;
            this.CoverageAmount = _coverageAmount;
            this.CoverageNumber = _coverageNumber;
        }
        public int AgentPlanId
        {
            get
            {
                return _AgentPlanId;
            }
            set
            {
                _AgentPlanId = value;
            }
        }

        public string AgentId
        {
            get
            {
                return _AgentId;
            }
            set
            {
                _AgentId = value;
            }
        }

        public int PlanCodeId
        {
            get
            {
                return planCodeId;
            }
            set
            {
                planCodeId = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        public long CoverageAmount
        {
            get
            {
                return _coverageAmount;
            }
            set
            {
                _coverageAmount = value;
            }
        }

        public int CoverageNumber
        {
            get
            {
                return _coverageNumber;
            }
            set
            {
                _coverageNumber = value;
            }
        }
    }
}




