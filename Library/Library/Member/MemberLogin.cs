using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class MemberLogin
    {
        public MemberLogin()
        {
            Console.SetWindowSize(50, 30);
        }

        List<Member> members = new List<Member>();
        
        
        public void PrintUserMenu()
        {
            Console.WriteLine("    ==================================");
            Console.WriteLine(" ");
            Console.WriteLine("              [1] 회원 가입           ");
            Console.WriteLine("              [2]  로그인             ");
            Console.WriteLine("              [2] 회원 탈퇴           ");
            Console.WriteLine("");
            Console.WriteLine("    ==================================");
        }

    }
}
