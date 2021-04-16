using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using ReLibrary.Model;
using ReLibrary.VO;


namespace ReLibrary.Controller
{
    class UserLoginPage
    {
        List<UserVO> userList;
        public UserLoginPage(List<UserVO> userList)
        {
            this.userList = userList;
            if(this.userList.Count == 0)
            {
                this.userList.Add(new UserVO("김현욱", "01050477361", "사우", "kimhw9821", "qwe123","김포고"));
            }
        }

        public void GoUserLoginNextMenu()
        {
            Except except = new Except();;
            Screen screen = new Screen();
            
            string check;
            int menu;

            Console.Clear();
            screen.PrintLabel();
            screen.PrintUserLoginPage();
            screen.PrintInput();
            check = Console.ReadLine();
            menu = except.HandleUserMenuExcept(check);
            GuideUserLoginMenu(menu);
        }

        public void GuideUserLoginMenu(int menu)
        {

            switch (menu)
            {

                case Constants.USER_LOGIN:
                    Login login = new Login(userList);
                    login.TryLogin();
                    break;


                case Constants.USER_SIGNUP:
                    SignUp signUp = new SignUp(userList);
                    signUp.CreateUser();
                    break;

                case Constants.USER_FIND:
                    break;

                case Constants.USER_WITHDRAW:
                    Secession secession = new Secession(userList);
                    secession.TrySecession();
                    break;

                case Constants.USER_BACK:
                    Console.Clear();
                    FirstPage first = new FirstPage(this.userList);
                    break;
            }
        }

        
    }
}
