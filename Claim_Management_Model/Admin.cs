using System;

namespace Claim_Management_Model
{
    public class Admin
    {
        private int _adminId;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _gender;
        private int _age;
        private long _contact;
        private string _emailId;
        private long _altContactNum;
        private string _password;
        private string _cnfPassword;
        private string _active;
        private string _favoritePerson;

        public Admin()
        {
            //do nothing
        }
        public Admin(string _emailId,string _pass)
        {
            this._emailId = _emailId;
            _password = _pass;
        }
        public Admin(int _adminId, string _firstName, string _lastName, DateTime _dateOfBirth, string _gender, int _age, long _contact, string _emailId, long _altContactNum, string _password, string _cnfPassword, string _active, string _favoritePerson)
        {
            this._adminId = _adminId;
            this._firstName = _firstName;
            this._lastName = _lastName;
            this._dateOfBirth = _dateOfBirth;
            this._gender = _gender;
            this._age = _age;
            this._contact = _contact;
            this._emailId = _emailId;
            this._altContactNum = _altContactNum;
            this._password = _password;
            this._cnfPassword = _cnfPassword;
            this._active = _active;
            this._favoritePerson = _favoritePerson;
        }

        public int AdminId
        {
            get
            {
                return _adminId;
            }
            set
            {
                _adminId = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public long Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
            }
        }

        public string EmailId
        {
            get
            {
                return _emailId;
            }
            set
            {
                _emailId = value;
            }
        }
        public long AltContact
        {
            get
            {
                return _altContactNum;
            }
            set
            {
                _altContactNum = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return _cnfPassword;
            }
            set
            {
                _cnfPassword = value;
            }
        }
        public string Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        public string Favoriteperson
        {
            get
            {
                return _favoritePerson;
            }
            set
            {
                _favoritePerson = value;
            }
        }
    }
}