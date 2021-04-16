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
    class UserLogin
    {
        List<UserVO> userList;
        public UserLogin(List<UserVO> userList)
        {
            this.userList = userList; 
        }

        public void GoUserLoginNextMenu()
        {
            Except except = new Except();
            Guide guide = new Guide();
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
                    Console.WriteLine(userList[0]);
                    break;


                case Constants.USER_SIGNUP:
                    LoadSingUpPage();
                    break;

                case Constants.USER_FIND:
                    break;

                case Constants.USER_WITHDRAW:
                    break;

                case Constants.USER_BACK:
                    Console.Clear();
                    FirstPage first = new FirstPage(this.userList);
                    break;
            }
        }

        public void LoadSingUpPage()
        {
            string name;
            string phoneNumber;
            string address;
            string id;
            string password;
            SignUp signUp = new SignUp();
            name = signUp.InputName();
            phoneNumber = signUp.InputNumber(name);
            address = signUp.InputAdress(name, phoneNumber);
            id = signUp.InputId(name, phoneNumber, address);
            password = signUp.InputPassword(name, phoneNumber, address, id);

            UserVO user = new UserVO(name, phoneNumber, address, id, password);
            userList.Add(user);

            Console.Clear();

            GoUserLoginNextMenu();
        }
    }
}
