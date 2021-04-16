using ReLibrary.Model;
using ReLibrary.VO;
using System;
using System.Collections.Generic;
using ReLibrary.Manager;

namespace ReLibrary.Controller
{
    class FirstPage
    {
        List<BooksVO> bookList;
        List<UserVO> userList;

        public FirstPage(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.bookList = bookList;
            this.userList = userList;

            Console.SetWindowSize(60, 30);
            ShowFirstPage();
        }

        // 첫번째 메뉴 화면
        public void ShowFirstPage()
        {
            Screen screen = new Screen();
            screen.PrintLabel();
            screen.PrintFirstPage();
            screen.PrintInput();
            GoSecondPage();
        }


        // 다음 메뉴화면으로 넘어가는 함수 
        public void GoSecondPage()
        {
            Except except = new Except();

            string check;
            int menu;

            check = Console.ReadLine();
            menu = except.HandleFirstMenuExcept(check);
            GuideFirstPageMenu(menu);
        }

        public void GuideFirstPageMenu(int menu)
        {
            switch (menu)
            {
                case Constants.USER_MENU:
                    UserLoginPage userLogin = new UserLoginPage(this.userList, this.bookList);
                    userLogin.GoUserLoginNextMenu();
                    break;

                case Constants.MANAGER_MENU:
                    ManagerLoginPage managerLoginPage = new ManagerLoginPage(userList, bookList);
                    managerLoginPage.TryManagerLogin();
                    break;

                case Constants.QUIT:
                    Environment.Exit(0);
                    break;
            }
        }

    }

}
