using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Management_Model
{
    public class DocUpload
    {
        private int _proofId;
        private string _reasonForClaiming;
        private string _idProof;
        private string _requiredDocument;
        private long _accountNumber;
        private string _ifscNumber;
        private string _accountHolder;

        public DocUpload()
        {
            //do nothing
        }

        public DocUpload(int _proofId,string _reasonForClaiming, string _idProof, string _requiredDocument, long _accountNumber, string _ifscNumber, string _accountHolder)
        {
            this._proofId = _proofId;
            this._reasonForClaiming = _reasonForClaiming;
            this._idProof = _idProof;
            this._requiredDocument = _requiredDocument;
            this._accountNumber = _accountNumber;
            this._ifscNumber = _ifscNumber;
            this._accountHolder = _accountHolder;
        }
        public int ProofID
        {
            get
            {
                return _proofId;
            }
            set
            {
                _proofId = value;
            }
        }
        public string ReasonForClaiming
        {
            get
            {
                return _reasonForClaiming;
            }
            set
            {
                _reasonForClaiming = value;
            }
        }
        public string IDProof
        {
            get
            {
                return _idProof;
            }
            set
            {
                _idProof = value;
            }
        }
        public string RequiredDocuments
        {
            get
            {
                return _requiredDocument;
            }
            set
            {
                _requiredDocument = value;
            }
        }
        public long AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                _accountNumber = value;
            }               
        }
        public string IFSCCode
        {
            get
            {
                return _ifscNumber;
            }
            set
            {
                _ifscNumber = value;
            }
        }
        public string AccountHolder
        {
            get
            {
                return _accountHolder;
            }
            set
            {
                _accountHolder = value;
            }
        }
    }
}
