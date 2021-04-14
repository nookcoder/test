using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Controller;

namespace ReLibrary.Model
{
    class Guide
    {
        public void GuideFirstPageMenu(int menu)
        {
            switch (menu)
            {
                case Constants.USER_MENU:
                    UserLogin userLogin = new UserLogin();
                    break;

                case Constants.MANAGER_MENU:
                    break;

                case Constants.QUIT:
                    Environment.Exit(0);
                    break;
            }
        }

        public void GuideUserLoginMenu(int menu)
        {
            switch (menu)
            {
                case Constants.USER_LOGIN:
                    break;

                case Constants.USER_SIGNUP:
                    break;

                case Constants.USER_FIND:
                    break;

                case Constants.USER_WITHDRAW:
                    break;

                case Constants.USER_BACK:
                    Console.Clear();
                    FirstPage first = new FirstPage();
                    break;
            }
        }
    }
}
