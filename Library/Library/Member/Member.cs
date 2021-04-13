using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Member
    {
        public Member(string _userName, string _phoneNumber,string _id, string _password)
        {
            this.UserName = _userName;
            this.PhoneNumber = _phoneNumber;
            this.Id = _id;
            this.Password = _password;
        }

        public string UserName
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set; 
        }
        
       


    }
}
