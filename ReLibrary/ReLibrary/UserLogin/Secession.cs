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
        List<UserVO> userList;

        public Secession(List<UserVO> userList)
        {
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
            screen.PrintSignUpId(null);
            Console.WriteLine(" ");
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
            int target; 

            for (int index = userList.Count; index > 0; index++)
            {
                if (userList[index-1].Id == id && userList[index-1].Password == password && userList[index-1].Hint == hint)
                {
                    userList.Remove(userList[index - 1]);
                    isFound = true;
                }
            }

            if(isFound)
            {
                UserLoginPage userLoginPage = new UserLoginPage(userList);

                Console.WriteLine(" ");
                Console.WriteLine("성공적으로 삭제되었습니다.");
                Console.ReadLine();
                userLoginPage.GoUserLoginNextMenu();
            }
        }

    }
}
