using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Model;

namespace ReLibrary.Manager
{
    class SearchUser
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public SearchUser(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList; 
        }

        public void LoadSearchingUserMenu()
        {
            string temp;
            int menu; 

            Screen screen = new Screen();
            Except except = new Except();

            Console.Clear();
            screen.PrintLabel();
            screen.PrintSearchingUserMenu();
            screen.PrintInput();
            temp = Console.ReadLine();
            menu = except.HandleSearchingUserMenuExcept(temp);

            switch(menu)
            {
                case Constants.SEARCHBYNAME:
                    SearchByName();
                    break;

                case Constants.SEARCHBYID:
                    SearchById();
                    break;

                case Constants.SEARCH_BACK:
                    ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                    managerMenu.LoadMangerMenu();
                    break;
            }
        }

        public void SearchByName()
        {
            string name;
            int noFind = 0;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintSignUpName(null);
            name = Console.ReadLine();

            for(int index = 0; index < userList.Count; index++)
            {
                if(name == userList[index].Name)
                {
                    ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                    Console.WriteLine(" ");
                    Console.WriteLine(userList[index]);
                }

                else
                {
                    noFind++;
                }
            }

            if(noFind == userList.Count)
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                
                Console.WriteLine("                    해당 회원은 존재하지 않습니다.");
                Console.ReadKey();
                Console.Clear();
                managerMenu.LoadMangerMenu();
            }

            else
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);

                Console.ReadKey();
                Console.Clear();
                managerMenu.LoadMangerMenu();
            }


        }

        public void SearchById()
        {
            string id;
            int noFind = 0;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintSignUpName(null);
            id = Console.ReadLine();

            for (int index = 0; index < userList.Count; index++)
            {
                if (id == userList[index].Id)
                {
                    ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                    Console.WriteLine(" ");
                    Console.WriteLine(userList[index]);
                }

                else
                {
                    noFind++;
                }
            }

            if (noFind == userList.Count)
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);

                Console.WriteLine("  해당 회원은 존재하지 않습니다.");
                Console.ReadKey();
                Console.Clear();
                managerMenu.LoadMangerMenu();
            }

            else
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);

                Console.ReadKey();
                Console.Clear();
                managerMenu.LoadMangerMenu();
            }
        }
    }
}
