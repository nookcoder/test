using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;



namespace ReLibrary.Controller
{
    class Secession
    {

        List<BooksVO> bookList;
        List<UserVO> userList;

        public Secession(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.bookList = bookList; 
            this.userList = userList;
        }

        public void TrySecession()
        {
            string id;
            string password;
            string hint;

            id = InputSecessionId();
            password = InputSecessionPassword();
            hint = InputSecessionHint();
            CheckSecession(id, password, hint);
        }

        public string InputSecessionId()
        {
            string id;

            Screen screen = new Screen();

            Console.Clear();
            Console.WriteLine(" ");
            screen.PrintLoginId(null);
            id = Console.ReadLine();
           
            return id;
        }

        public string InputSecessionPassword()
        {
            string password;

            Screen screen = new Screen();

            screen.PrintSignUpPassword();
            password = Console.ReadLine();

            return password;
        }
        public string InputSecessionHint()
        {
            string hint;

            Screen screen = new Screen();

            screen.PrintAskHint();
            hint = Console.ReadLine();

            return hint;
        }

        public void CheckSecession(string id, string password, string hint)
        {
            bool isFound = false;

            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id && userList[index].Password == password && userList[index].Hint == hint)
                {
                    userList.Remove(userList[index]);
                    isFound = true;
                }
            }

            if(isFound)
            {
                UserLoginPage userLoginPage = new UserLoginPage(userList, bookList);
                Console.WriteLine(" ");
                Console.WriteLine("                    성공적으로 삭제되었습니다.");
                Console.ReadLine();
                userLoginPage.GoUserLoginNextMenu();
            }

            else
            {
                UserLoginPage userLoginPage = new UserLoginPage(userList, bookList);
                Console.WriteLine(" ");
                Console.WriteLine("                    정보가 맞지 않습니다..");
                Console.ReadLine();
                userLoginPage.GoUserLoginNextMenu();
            }
        }

    }
}
