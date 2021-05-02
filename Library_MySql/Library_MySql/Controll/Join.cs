using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Join
    {
        public Join()
        {

        }

        public string Getid()
        {
            string idCheck;
            string id;
            Initialization.screen.PrintGetId();
            idCheck = Console.ReadLine();
            id = Initialization.exception.HandleGetId(idCheck);

            return id;
        }

        public string GetPassword()
        {
            string passwordCheck;
            string password;
            Initialization.screen.PrintGetPassword();
            passwordCheck = Console.ReadLine();
            password = Initialization.exception.HandleGetPassword(passwordCheck);

            return password;
        }

        public string GetName()
        {
            string nameCheck;
            string name;
            Initialization.screen.PrintGetPassword();
            nameCheck = Console.ReadLine();
            name = Initialization.exception.HandleGetPassword(nameCheck);

            return name;
        }
    }
}
