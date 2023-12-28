using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class UserBO
    {
        //Declaring User Registration Variables  
        private string _Name;
        private string _Address;
        private string _EmailID;
        private string _Mobilenumber;
        private string _country;
        private string _sex;
        private string _dbo;

        public UserBO()
        {

        }

        public UserBO (string name, string address, string email)
        {
            _Name = name;
            _Address = address;
            _EmailID = email;
        }
        // Get and set values  
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        public string EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }
        }
        public string Mobilenumber
        {
            get
            {
                return _Mobilenumber;
            }
            set
            {
                _Mobilenumber = value;
            }
        }
        public string country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }
        public string sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
            }
        }
        public string dbo
        {
            get
            {
                return _dbo;
            }
            set
            {
                _dbo = value;
            }
        }

        public string SexName { get {return _sex == "True" ? "Male" : "Female"; } }

        public string DOBDisplay
        {
            get
            {
                return string.IsNullOrEmpty(_dbo) ? "NA" : string.Format("{0:dd-MM-yyyy}", DateTime.Parse(dbo));
            }
        }

        public int CheckValidation()
        {
            bool isValid = false;
            // check email
            string exprestion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            isValid = Regex.IsMatch(this.EmailID, exprestion);
            if (isValid == true)
            {
                // check mobile number
                string checkp = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";

                isValid = Regex.IsMatch(this.Mobilenumber, checkp);
                if (!isValid)
                {
                    //failed mobile
                    return -2;
                }
            }
            else
            {
                // failed email
                return -1;
            }
            if(this.sex==null)
            {
                return -3;
            }
            if(this._dbo!=null)
            {
                return -4;
            }


            //success
            return 0;
        }
    }
}
