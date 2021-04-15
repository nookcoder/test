using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Model;

namespace ReLibrary.Controller
{
    class FirstPage
    {
        public FirstPage()
        {
            Console.SetWindowSize(60, 30);
            Screen screen = new Screen();
            screen.PrintLabel();
            screen.PrintFirstPage();
            screen.PrintInput();
            GoSecondPage();
        }

        public void GoSecondPage()
        {
            Except except = new Except();
            Guide guide = new Guide();

            string check;
            int menu;

            check = Console.ReadLine();
            menu = except.HandleFirstMenuExcept(check);
            guide.GuideFirstPageMenu(menu);
        }
    }

}
