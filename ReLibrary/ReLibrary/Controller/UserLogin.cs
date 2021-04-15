using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Model;

namespace ReLibrary.Controller
{
    class UserLogin
    {
        public UserLogin()
        {
            
        }

        public void GoUserLoginNextMenu()
        {
            Except except = new Except();
            Guide guide = new Guide();
            string check;
            int menu;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintLabel();
            screen.PrintUserLoginPage();
            screen.PrintInput();
            check = Console.ReadLine();
            menu = except.HandleUserMenuExcept(check);
            guide.GuideUserLoginMenu(menu);
        }

    }
}
