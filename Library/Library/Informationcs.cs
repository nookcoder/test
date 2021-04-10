using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Get
    {
        public string id = string.Empty;
        public string password = string.Empty;

        public void GetInformation()
        {
            Console.Write("아이디 : ");
            id = Console.ReadLine();
            Console.Write("비밀번호 : ");
            password = Console.ReadLine(); 
        }
    }
}
