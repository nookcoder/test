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
        List<BooksVO> bookList;
        List<UserVO> userList;
        public UserLoginPage(List<UserVO> userList,List<BooksVO> bookList)
        {
            this.bookList = bookList;
            this.userList = userList;
        }

        // 유저 로그인관련 화면 
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
                    Login login = new Login(userList, bookList);
                    login.TryLogin();
                    break;


                case Constants.USER_SIGNUP:
                    SignUp signUp = new SignUp(userList, bookList);
                    signUp.CreateUser();
                    break;

                case Constants.USER_FIND:
                    break;

                case Constants.USER_WITHDRAW:
                    Secession secession = new Secession(userList, bookList);
                    secession.TrySecession();
                    break;

                case Constants.USER_BACK:
                    Console.Clear();
                    FirstPage first = new FirstPage(userList,bookList);
                    break;
            }
        }

        
    }
}
