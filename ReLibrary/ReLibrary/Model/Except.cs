using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.View;

namespace ReLibrary.Model
{
    class Except
    {
        public int HandleFirstMenuExcept(string check)
        {
            int menu = Constants.RESET;
            bool isError = true;

            while(isError)
            {
                if(check == "1" || check == "2" || check == "3")
                {
                    menu = int.Parse(check);
                    isError =Constants.NOERROR;
                }

                else
                {
                    Console.Clear();
                    Common common = new Common();
                    FirstPageScreen firstPage = new FirstPageScreen();
                    common.PrintPageError();
                    common.PrintInput();
                    check = Console.ReadLine();
                }
            }

            return menu; 
        }

        public int HandleUserloginExcept(string check)
        {
            int menu = Constants.RESET;
            bool isError = true;

            while (isError)
            {
                if (check == "1" || check == "2" || check == "3" || check == "4"|| check == "5")
                {
                    menu = int.Parse(check);
                    isError = Constants.NOERROR;
                }

                else
                {
                    Console.Clear();
                    Common common = new Common();
                    UserLoginScreen userLoginScreen = new UserLoginScreen();
                    common.PrintPageError();
                    common.PrintInput();
                    check = Console.ReadLine();
                }
            }

            return menu;
        }
    }
}
