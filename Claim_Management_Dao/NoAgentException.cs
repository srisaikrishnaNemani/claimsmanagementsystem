using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Management_Dao
{
    class NoAgentException : Exception
    {
        private string _message;

        public NoAgentException()
        {

        }

        public NoAgentException(string _message)
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

