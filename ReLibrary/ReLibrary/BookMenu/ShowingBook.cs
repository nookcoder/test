using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Model;
using ReLibrary.User;

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

        // 도서 전체 조회
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

        // 도서 검색 
        public void LoadSearchBookMenu()
        {
            string temp;
            int menu; 

            Screen screen = new Screen();
            Except except = new Except();
            
            Console.Clear();
            Console.WriteLine(" ");
            screen.PrintSearchBookMenu();
            screen.PrintInput();
            temp = Console.ReadLine();
            
            menu = except.HandleSearchBookMenuExcept(temp);
            
            switch (menu)
            {
                case Constants.SEARCH_BY_TITLE:
                    SearchByTitle();
                    break;

                case Constants.SEARCH_BY_AUTHOR:
                    SearchByAuthor();
                    break;
               
                case Constants.SEARCH_BACK:
                    ManagerMenu managerMenu = new ManagerMenu(userList,bookList);
                    managerMenu.LoadMangerMenu();
                    break;

            }
        }

        public void SearchByTitle()
        {
            string title;
            int noFind = 0; 

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintBookTitle(null);
            title = Console.ReadLine();

            for(int index = 0; index < bookList.Count; index++)
            {
                if(bookList[index].Title == title)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(bookList[index]);
                }

                else
                {
                    noFind++; 
                }
            }
            
            if(noFind == bookList.Count)
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

        public void SearchByAuthor()
        {
            string author;
            int noFind = 0;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintBookAuthor(null);
            author = Console.ReadLine();

            for (int index = 0; index < bookList.Count; index++)
            {
                if (bookList[index].Author == author)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(bookList[index]);
                }

                else
                {
                    noFind++;
                }
            }

            if (noFind == bookList.Count)
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
