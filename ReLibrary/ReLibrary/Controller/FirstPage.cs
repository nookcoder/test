using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.View;
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
            FirstPageModel firstPageModel = new FirstPageModel();
            Input input = new Input();

            string check;
            int menu;
            
            check = input.RequestInput();
            menu = except.HandleFirstMenuExcept(check);
            firstPageModel.GuideFirstPageMenu(menu);
        }
    }

}
