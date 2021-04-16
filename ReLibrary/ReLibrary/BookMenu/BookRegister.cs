using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Model;

namespace ReLibrary.Manager
{
    class BookRegister
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public BookRegister(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void RegisterBook()
        {
            string bookNumber;
            string bookTitle;
            string author;
            string publisher;

            bookNumber = InputBookNumber();
            bookTitle = InputBookTitle(bookNumber);
            author = InputBookAuthor(bookNumber,bookTitle);
            publisher = InputBookPublisher(bookNumber,bookTitle,author);

            bookList.Add(new BooksVO(bookNumber, bookTitle, author, publisher));

            Console.WriteLine(" ");
            Console.WriteLine("                    등록이 완료됐습니다. ");
            Console.ReadLine();
            Console.Clear();
            ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
            managerMenu.LoadMangerMenu();
        }

        public string InputBookNumber()
        {
            string bookNumber;
            string temp;
            
            Screen screen = new Screen();
            Except except = new Except();

            Console.Clear();
            screen.PrintBookNumber(null);
            temp = Console.ReadLine();
            bookNumber = except.HandleBookNumberExcept(temp);

            return bookNumber;
        }

        public string InputBookTitle(string bookNumber)
        {
            string bookTitle;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintBookNumber(bookNumber);
            screen.PrintBookTitle(null);
            bookTitle = Console.ReadLine();

            return bookTitle;
        }

        public string InputBookAuthor(string bookNumber, string bookTitle)
        {
            string author;

            Screen screen = new Screen();

            Console.Clear();
            screen.PrintBookNumber(bookNumber);
            screen.PrintBookTitle(bookTitle);
            screen.PrintBookAuthor(null);
            author = Console.ReadLine();

            return author;
        }

        public string InputBookPublisher(string bookNumber, string bookTitle, string author)
        {
            string publisher;

            Screen screen = new Screen();

            Console.Clear();
            screen.PrintBookNumber(bookNumber);
            screen.PrintBookTitle(bookTitle);
            screen.PrintBookAuthor(author);
            screen.PrintBookPublisher(null);
            publisher = Console.ReadLine();

            return publisher;
        }
    }
}
