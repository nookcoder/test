using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Member
    {
        public Member(string _memberName, string _phoneNumber,string _Memberid, string _password)
        {
            this.MemberName = _memberName;
            this.PhoneNumber = _phoneNumber;
            this.MemberId = _Memberid;
            this.Password = _password;
        }

        public string MemberName
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string MemberId
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
