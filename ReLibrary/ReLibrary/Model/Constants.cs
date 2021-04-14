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
        public const int USER_MENU = 1;
        public const int MANAGER_MENU = 2;
        public const int QUIT = 3;

        // 회원 메뉴 
        public const int USER_LOGIN = 1;
        public const int USER_SIGNUP = 2;
        public const int USER_WITHDRAW = 3;
        public const int USER_FIND = 4;
        public const int USER_BACK = 5;

        // 회원 도서 메뉴 
        public const int SEARCH_BOOK = 1;
        public const int BORROW_BOOK = 2;
        public const int RETURN_BOOK = 3;
        public const int BOOK_BACk = 4; 

        // 관리자 메뉴 
        public const int USER_INFORMATION = 1;
        public const int MANAGER_WITHDARW = 2;
        public const int RESISTER_BOOK = 3;
        public const int REVISE_BOOK = 4;
        public const int DELET_BOOK = 5;
        public const int PRINT_BOOK = 6;
        public const int MANAGER_BACK = 7;

        // 기타
        public const bool NOERROR = false;
        public const bool FOUND = true;
        public const int RESET = 0;
        
    }
}
