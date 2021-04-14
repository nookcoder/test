using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.View;
using ReLibrary.Model;

namespace ReLibrary.Controller
{
    class FirstPageController
    {
        public FirstPageController()
        {
            Console.SetWindowSize(60, 30);
            Common common = new Common();
            FirstPage firstPage = new FirstPage();
            common.PrintInput();
            GoSecondPage();
        }
        public string GETFirstPage()
        {
            string menu;
            menu = Console.ReadLine();

            return menu;
        }

        public void GoSecondPage()
        {
            Except except = new Except();
            FirstPageModel firstPageModel = new FirstPageModel();
            string check;
            int menu;
            
            check = GETFirstPage();
            menu = except.HandleFirstMenuExcept(check);
            firstPageModel.TakeFirstPageMenu(menu);
        }
    }

}
