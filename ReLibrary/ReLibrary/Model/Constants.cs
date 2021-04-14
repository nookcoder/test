using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReLibrary.Model
{
    public class Constants
    {
        // 초기 화면 
        public const int USERMENU = 1;
        public const int MANAGERMENU = 2;
        public const int QUIT = 3;

        // 회원 메뉴 
        public const int USERLOGIN = 1;
        public const int USERSIGNUP = 2;
        public const int USER1WITHDRAW = 3;
        public const int USERBASCK = 4;
        public const int USERBACK = 5;

        // 회원 도서 메뉴 
        public const int SEARCHBOOK = 1;
        public const int BORROWBOOK = 2;
        public const int RETURNBOOK = 3;
        public const int BOOKBACK = 4; 

        // 관리자 메뉴 
        public const int USERINFORMATION = 1;
        public const int MANAGERWITHDARW = 2;
        public const int RESISTERBOOK = 3;
        public const int REVISEBOOK = 4;
        public const int DELETBOOK = 5;
        public const int PRINTBOOK = 6;
        public const int MANAGERBACK = 7;

        // 기타
        public const bool NOERROR = false;
        public const bool FOUND = true;
        public const int RESET = 0;
        
    }
}
