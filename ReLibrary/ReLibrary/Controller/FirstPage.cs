using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Model;
using ReLibrary.VO;
using System.Security;

namespace ReLibrary.Controller
{
    class FirstPage
    {
        List<UserVO> userList;
        public FirstPage(List<UserVO> userList)
        {
            this.userList = userList;
            Console.SetWindowSize(60, 30);
            ShowFirstPage();
        }

        public void ShowFirstPage()
        {
            Screen screen = new Screen();
            screen.PrintLabel();
            screen.PrintFirstPage();
            screen.PrintInput();
            GoSecondPage();
        }

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
            UserLogin userLogin = new UserLogin(this.userList);
            switch (menu)
            {
                case Constants.USER_MENU:
                    userLogin.GoUserLoginNextMenu();
                    break;

                case Constants.MANAGER_MENU:
                    break;

                case Constants.QUIT:
                    Environment.Exit(0);
                    break;
            }
        }

    }

}
