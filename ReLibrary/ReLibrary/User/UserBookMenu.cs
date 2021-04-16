using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Model;
using ReLibrary.Controller;
using ReLibrary.Manager;
using ReLibrary.BookMenu;

namespace ReLibrary.User
{
    class UserBookMenu
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public UserBookMenu(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void LoadUserBookMenu()
        {
            string temp;
            int menu;
            
            Screen screen = new Screen();
            Except except = new Except();

            screen.PrintLabel();
            screen.PrintUserBookMenu();
            screen.PrintInput();
            temp = Console.ReadLine();
            menu = except.HandleUserBookMenuExcept(temp);

            switch(menu)
            {
                case Constants.SEARCH_BOOK:
                    ShowingBook_User showingBook_User = new ShowingBook_User(userList,bookList);
                    showingBook_User.LoadSearchBookMenu_User();
                    break;

                case Constants.BORROW_BOOK:
                    break;

                case Constants.RETURN_BOOK:
                    
                    break;

                case Constants.BOOK_BACk:
                    UserLoginPage userLoginPage = new UserLoginPage(userList, bookList);
                    userLoginPage.GoUserLoginNextMenu();
                    break;
            }
        }

        
    }
}
