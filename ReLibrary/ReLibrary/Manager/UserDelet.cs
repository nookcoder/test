using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Controller;

namespace ReLibrary.Manager
{
    class UserDelet
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public UserDelet(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void TryDelet()
        {
            string id;
            string password;
            
            Secession secession = new Secession(userList,bookList);

            id = secession.InputSecessionId();
            password = secession.InputSecessionPassword();
            CheckDelet(id, password);
        }

        public void CheckDelet(string id, string password)
        {
            bool isFound = false;

            for (int index = 0; index < userList.Count; index++)
            {
                if (userList[index].Id == id && userList[index].Password == password)
                {
                    userList.Remove(userList[index]);
                    isFound = true;
                }
            }

            if (isFound)
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                Console.WriteLine(" ");
                Console.WriteLine("                    성공적으로 삭제되었습니다.");
                Console.ReadLine();
                managerMenu.LoadMangerMenu();
            }

            else
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                Console.WriteLine(" ");
                Console.WriteLine("                    정보가 맞지 않습니다..");
                Console.ReadLine();
                managerMenu.LoadMangerMenu();
            }
        }

    }
}
