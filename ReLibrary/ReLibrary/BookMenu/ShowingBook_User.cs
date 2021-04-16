using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Controller;
using ReLibrary.Model;
using ReLibrary.User;

namespace ReLibrary.BookMenu
{
    class ShowingBook_User
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        // 회원이 도서 검색할 때 나올 화면
        public ShowingBook_User(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }
        public void LoadSearchBookMenu_User()
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
                    SearchByTitle_User();
                    break;

                case Constants.SEARCH_BY_AUTHOR:
                    SearchByAuthor_User();
                    break;

                case Constants.SEARCH_BACK:
                    UserBookMenu userBookMenu = new UserBookMenu(userList, bookList);
                    userBookMenu.LoadUserBookMenu();
                    break;

            }
        }

        public void SearchByTitle_User()
        {
            string title;
            int noFind = 0;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintBookTitle(null);
            title = Console.ReadLine();

            for (int index = 0; index < bookList.Count; index++)
            {
                if (bookList[index].Title == title)
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
                UserBookMenu userBookMenu = new UserBookMenu(userList, bookList);

                Console.WriteLine("                    해당 도서는 존재하지 않습니다.");
                Console.ReadKey();
                Console.Clear();
                userBookMenu.LoadUserBookMenu();
            }

            else
            {
                UserBookMenu userBookMenu = new UserBookMenu(userList, bookList);

                Console.ReadKey();
                Console.Clear();
                userBookMenu.LoadUserBookMenu();
            }
        }

        public void SearchByAuthor_User()
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
                UserBookMenu userBookMenu = new UserBookMenu(userList, bookList);

                Console.WriteLine(" ");
                Console.WriteLine("                    해당 도서는 존재하지 않습니다.");
                Console.ReadKey();
                Console.Clear();
                userBookMenu.LoadUserBookMenu();
            }

            else
            {
                UserBookMenu userBookMenu = new UserBookMenu(userList, bookList);

                Console.ReadKey();
                Console.Clear();
                userBookMenu.LoadUserBookMenu();
            }
        }
    }
}
