using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
