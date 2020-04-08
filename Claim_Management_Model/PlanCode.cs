using System;

namespace Claim_Management_Model
{
    public class PlanCode
    {
        private int _planCodeId;
        private string _planName;
        private string _planDescription;
        private long _coverage1;
        private long _coverage2;
        private long _coverage3;
        private long _coverage4;
        private long _coverage5;

        public PlanCode()
        {

        }

        public PlanCode(int _planCodeId, string _planName, string _planDescription, long _coverage1, long _coverage2, long _coverage3, long _coverage4, long _coverage5)
        {
            this.PlanCodeId = _planCodeId;
            this.PlanName = _planName;
            this.PlanDescription = _planDescription;
            this.Coverage1 = _coverage1;
            this.Coverage2 = _coverage2;
            this.Coverage3 = _coverage3;
            this.Coverage4 = _coverage4;
            this.Coverage5 = _coverage5;
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

        public long Coverage1
        {
            get
            {
                return _coverage1;
            }

            set
            {
                _coverage1 = value;
            }
        }

        public long Coverage2
        {
            get
            {
                return _coverage2;
            }

            set
            {
                _coverage2 = value;
            }
        }

        public long Coverage3
        {
            get
            {
                return _coverage3;
            }

            set
            {
                _coverage3 = value;
            }
        }

        public long Coverage4
        {
            get
            {
                return _coverage4;
            }

            set
            {
                _coverage4 = value;
            }
        }

        public long Coverage5
        {
            get
            {
                return _coverage5;
            }

            set
            {
                _coverage5 = value;
            }
        }
    }
}