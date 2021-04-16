using ReLibrary.Controller;
using ReLibrary.VO;
using System;
using System.Collections.Generic;

namespace ReLibrary.Manager
{
    class ManagerLoginPage
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public ManagerLoginPage(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void TryManagerLogin()
        {
            string Id;
            string password;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintLoginId(null);
            Id = Console.ReadLine();
            screen.PrintSignUpPassword();
            password = Console.ReadLine();
            CheckManagerIdPassword(Id, password);
        }

        public void CheckManagerIdPassword(string id, string password)
        {
            if (id == "En#" && password == "21")
            {
                //
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("              관리자 로그인에 실패했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                FirstPage first = new FirstPage(userList, bookList);
                first.GoSecondPage();
            }
        }
    }
}
