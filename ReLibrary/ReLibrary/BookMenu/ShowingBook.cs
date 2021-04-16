using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;

namespace ReLibrary.Manager
{
    class ShowingBook
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public ShowingBook(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void ShowAllBook()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("============================================================");
            Console.WriteLine("\n");
            for (int index=0; index < bookList.Count; index++)
            {
                Console.WriteLine(bookList[index].ToString());
                Console.WriteLine("");
            }

            Console.ReadKey();
            Console.Clear();
            ManagerMenu manager = new ManagerMenu(userList,bookList);
            manager.LoadMangerMenu();
        }

        public void ShowSearchBook()
        {
            string target;
            int noFind = 0;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintBookSearch();
            target = Console.ReadLine();

            for (int index = 0; index < userList.Count; index++)
            {
                if (target == bookList[index].Title || target == bookList[index].Author)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(bookList[index]);
                }

                else
                {
                    noFind++;
                }
            }

            if (noFind == userList.Count)
            {
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);

                Console.WriteLine("                    해당 도서는 존재하지 않습니다.");
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
