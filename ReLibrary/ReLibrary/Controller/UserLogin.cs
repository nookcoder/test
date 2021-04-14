using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Model;
using ReLibrary.View;

namespace ReLibrary.Controller
{
    class UserLogin
    {
        public UserLogin()
        {
            Screen screen = new Screen();
            Console.Clear();
            screen.PrintLabel();
            screen.PrintUserLoginPage();
            screen.PrintInput();
            GoUserLoginNextMenu();
        }

        public void GoUserLoginNextMenu()
        {
            Except except = new Except();
            UserLoginModel userLoginModel = new UserLoginModel();
            string check;
            int menu;

            check = Console.ReadLine();
            menu = except.HandleUserloginExcept(check);
            userLoginModel.GuideUserLoginMenu(menu);
        }
    }
}
