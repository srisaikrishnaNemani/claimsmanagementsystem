using System;

namespace Claim_Management_Dao
{
    public class NoMemberException : Exception
    {
        private string _message;

        public NoMemberException()
        {

        }

        public NoMemberException(string _message)
        {
            this.Message1 = _message;
        }

        public string Message1
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}", this._message);
        }
    }
}