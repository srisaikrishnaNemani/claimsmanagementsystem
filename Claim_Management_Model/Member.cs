using System;

namespace Claim_Management_Model
{
    public class Member : MemberPlan
    {
        private int _memberID;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _gender;
        private int _age;
        private long _contactNum;
        private string _emailID;
        private long _altContact;
        private string _password;
        private string _cnfPassword;
        private long _planCode;
        private DateTime _covStartDate;
        private DateTime _covEndDate;
        private string _addrLine1;
        private string _addrLine2;
        private string _city;
        private string _state;
        private int _zipCode;
        private string _active;
        private string _favoritePerson;


        public Member()
        {
            //do nothing
        }
        public Member (string _emailID,string _password)
        {
            this._emailID = _emailID;
            this._password = _password;
        }

        public Member(int _memberID, string _firstName, string _lastName, DateTime _dateOfBirth, string _gender, int _age, long _contactNum, string _emailID, long _altContact, string _password, string _cnfPassword, long _planCode, DateTime _covStartDate, DateTime _covEndDate, string _addrLine1, string _addrLine2, string _city, string _state, int _zipCode, string _active, string _favoritePerson)
        {
            this._memberID = _memberID;
            this._firstName = _firstName;
            this._lastName = _lastName;
            this._dateOfBirth = _dateOfBirth;
            this._gender = _gender;
            this._age = _age;
            this._contactNum = _contactNum;
            this._emailID = _emailID;
            this._altContact = _altContact;
            this._password = _password;
            this._cnfPassword = _cnfPassword;
            this._planCode = _planCode;
            this._covStartDate = _covStartDate;
            this._covEndDate = _covEndDate;
            this._addrLine1 = _addrLine1;
            this._addrLine2 = _addrLine2;
            this._city = _city;
            this._state = _state;
            this._zipCode = _zipCode;
            this._active = _active;
            this._favoritePerson = _favoritePerson;

        }

        public int MemberID
        {
            get
            {
                return _memberID;
            }
            set
            {
                _memberID = value;
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
                return _contactNum;
            }
            set
            {
                _contactNum = value;
            }
        }

        public string EmailId
        {
            get
            {
                return _emailID;
            }
            set
            {
                _emailID = value;
            }
        }
        public long AltContact
        {
            get
            {
                return _altContact;
            }
            set
            {
                _altContact = value;
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

        public long PlanCode
        {
            get
            {
                return _planCode;
            }
            set
            {
                _planCode = value;
            }
        }
        public DateTime CovStartDate
        {
            get
            {
                return _covStartDate;
            }
            set
            {
                _covStartDate = value;
            }
        }
        public DateTime CovEndDate
        {
            get
            {
                return _covEndDate;
            }
            set
            {
                _covEndDate = value;
            }
        }

        public String AddrsLine1
        {
            get
            {
                return _addrLine1;
            }
            set
            {
                _addrLine1 = value;
            }
        }


        public String AddrsLine2
        {
            get
            {
                return _addrLine2;
            }
            set
            {
                _addrLine2 = value;
            }
        }

        public String City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        public String State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public int ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
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

        public string FavoritePerson
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