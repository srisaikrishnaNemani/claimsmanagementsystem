using System;

namespace Claim_Management_Model
{
    public class Claim : Member 
    {
        private int _id;
        private int _claimId;
        private string _memberId;
        private DateTime _claimServiceDate;
        private DateTime _claimSubmissionDate;
        private DateTime _claimProcessingDate;
        private string _claimStatus;
        private long _claimAmount;
        private long _approvedAmount;
        private int _cmid;
        private string _planName;

        public Claim()
        {
            //do nothing
        }
        public Claim(int _id,int _claimId, string _memberId, DateTime _claimServiceDate, DateTime _claimSubmissionDate, DateTime _claimProcessingDate, string _claimStatus, long _claimAmount, long _approvedAmount, int _cmid, string _planName)
        {
            this._id = _id;
            this._claimId = _claimId;
            this._memberId = _memberId;
            this._claimServiceDate = _claimServiceDate;
            this._claimSubmissionDate = _claimSubmissionDate;
            this._claimProcessingDate = _claimProcessingDate;
            this._claimStatus = _claimStatus;
            this._claimAmount = _claimAmount;
            this._approvedAmount = _approvedAmount;
            this._cmid = _cmid;
            this._planName = _planName;
        }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public int ClaimId
        {
            get
            {
                return _claimId;
            }
            set
            {
                _claimId = value;
            }
        }
        public string Member_Id
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

        public DateTime ClaimServiceDate
        {
            get
            {
                return _claimServiceDate;
            }

            set
            {
                _claimServiceDate = value;
            }
        }

        public DateTime ClaimSubmissionDate
        {
            get
            {
                return _claimSubmissionDate;
            }

            set
            {
                _claimSubmissionDate = value;
            }
        }

        public DateTime ClaimProcessingDate
        {
            get
            {
                return _claimProcessingDate;
            }

            set
            {
                _claimProcessingDate = value;
            }
        }

        public long ClaimAmount
        {
            get
            {
                return _claimAmount;
            }

            set
            {
                _claimAmount = value;
            }
        }

        public long ApprovedAmount
        {
            get
            {
                return _approvedAmount;
            }

            set
            {
                _approvedAmount = value;
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

        public int CMID
        {
            get
            {
                return _cmid;
            }
            set
            {
                _cmid = value;
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
        
    }
}