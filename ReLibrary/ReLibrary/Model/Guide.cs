using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Controller;
using ReLibrary.VO;

namespace ReLibrary.Model
{
    class Guide
    {
        public void GuideFirstPageMenu(int menu)
        {
            UserLogin userLogin = new UserLogin();
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

        public void GuideUserLoginMenu(int menu)
        {
            List<User> list = new List<User>();
            UserLogin userLogin = new UserLogin();
            SignUp signUp = new SignUp();
            switch (menu)
            {

                case Constants.USER_LOGIN:
                    break;

                case Constants.USER_SIGNUP:
                    signUp.LoadSingUpPage();
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
