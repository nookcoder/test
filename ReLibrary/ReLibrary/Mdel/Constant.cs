using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReLibrary.Mdel
{
    public class Constant
    {
        // 초기 화면 
        private const int USERMENU = 1;
        private const int MANAGERMENU = 2;
        private const int QUIT = 3;

        // 회원 메뉴 
        private const int USERLOGIN = 1;
        private const int USERSIGNUP = 2;
        private const int USER1WITHDRAW = 3;
        private const int USERBASCK = 4;
        private const int USERBACK = 5;

        // 회원 도서 메뉴 
        private const int SEARCHBOOK = 1;
        private const int BORROWBOOK = 2;
        private const int RETURNBOOK = 3;
        private const int BOOKBACK = 4; 

        // 관리자 메뉴 
        private const int USERINFORMATION = 1;
        private const int MANAGERWITHDARW = 2;
        private const int RESISTERBOOK = 3;
        private const int REVISEBOOK = 4;
        private const int DELETBOOK = 5;
        private const int PRINTBOOK = 6;
        private const int MANAGERBACK = 7; 
    }
}
