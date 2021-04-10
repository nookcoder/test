using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Member
    {
        public Member(string _id, string _password)
        {
            this.id = _id;
            this.password = _password; 
        }

        private string id;
        private string password;
        public string Id
        {
            get { return id; }
            set { id = value;  }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
       


    }
}
