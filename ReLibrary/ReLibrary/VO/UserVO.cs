using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Security.SecureString;

namespace ReLibrary.VO
{
    class UserVO
    {
        private string name;
        private string phoneNumber;
        private string address;
        private string id;
        private string password; //SecureString 
        private string hint;

        public UserVO(string name, string phoneNumber, string address, string id, string password,string hint)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.id = id;
            this.password = password;
            this.hint = hint;
        }
       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNumbe
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Hint
        {
            get { return hint; }
            set { hint = value; }
        }
        public override string ToString() => $"{name} {phoneNumber} {address} {id}.{password}";
    }
}
