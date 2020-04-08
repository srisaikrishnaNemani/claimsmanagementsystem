using System;

namespace Claim_Management_Model
{
    public class ClaimApproval
    {
        private int _planCodeId;
        private string _planName;
        private string _planDescription;
        private DateTime _startDate;
        private DateTime _endDate;
        private float _coverageAmount;
        private string _claimStatus;

        public ClaimApproval()
        {
            //do nothing
        }
        public ClaimApproval(int _planCodeId, string _planName, string _planDescription, DateTime _startDate, DateTime _endDate, float _coverageAmount, string _claimStatus)
        {
            this._planCodeId = _planCodeId;
            this._planName = _planName;
            this._planDescription = _planDescription;
            this._startDate = _startDate;
            this._endDate = _endDate;
            this._coverageAmount = _coverageAmount;
            this._claimStatus = _claimStatus;
        }

        public int PlanCodeId
        {
            get
            {
                return _planCodeId;
            }

            set
            {
                _planCodeId = value;
            }
        }

        public string PlanName
        {
            get
            {
                return _planName;
            }

            set
            {
                _planName = value;
            }
        }

        public string PlanDescription
        {
            get
            {
                return _planDescription;
            }

            set
            {
                _planDescription = value;
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

        public float CoverageAmount
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

        public string ClaimStatus
        {
            get
            {
                return _claimStatus;
            }

            set
            {
                _claimStatus = value;
            }
        }
    }
}
