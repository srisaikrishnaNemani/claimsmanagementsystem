using System;

namespace Claim_Management_Model
{
    public class MemberPlan : PlanCode
    {
        private int _memberPlanId;
        private string _memberId;
        private int planCodeId;
        private DateTime _startDate;
        private DateTime _endDate;
        private long _coverageAmount;
        private int _coverageNumber;

        public MemberPlan()
        {

        }

        public MemberPlan(int _memberPlanId, string _memberId, int planCodeId, DateTime _startDate, DateTime _endDate, long _coverageAmount, int _coverageNumber)
        {
            this.MemberPlanId = _memberPlanId;
            this.MemberId = _memberId;
            this.PlanCodeId = planCodeId;
            this.StartDate = _startDate;
            this.EndDate = _endDate;
            this.CoverageAmount = _coverageAmount;
            this.CoverageNumber = _coverageNumber;
        }
        public int MemberPlanId
        {
            get
            {
                return _memberPlanId;
            }
            set
            {
                _memberPlanId = value;
            }
        }

        public string MemberId
        {
            get
            {
                return _memberId;
            }
            set
            {
                _memberId = value;
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
