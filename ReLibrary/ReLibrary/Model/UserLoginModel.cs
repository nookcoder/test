using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Controller;

namespace ReLibrary.Model
{
    class UserLoginModel
    {
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
