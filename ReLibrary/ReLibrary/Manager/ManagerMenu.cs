using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Model;
using ReLibrary.Controller;

namespace ReLibrary.Manager
{

    class ManagerMenu
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public ManagerMenu(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void LoadMangerMenu()
        {
            string temp;
            int menu;

            Except except = new Except();
            Screen screen = new Screen();

            Console.Clear();
            screen.PrintLabel();
            screen.PrintManagerMenu();
            screen.PrintInput();
            temp = Console.ReadLine();
            menu = except.HandleManagerMenuExcept(temp);
            GuideManagerMenu(menu);
        }

        public void GuideManagerMenu(int menu)
        {
            switch(menu)
            {
                case Constants.MANAGER_REGISTER:
                    UserRegister userRegister = new UserRegister(userList, bookList);
                    userRegister.RegisterUser();
                    break;

                case Constants.MANAGER_DELET:
                    UserDelet userDelet = new UserDelet(userList, bookList);
                    userDelet.TryDelet();
                    break;

                case Constants.USER_INFORMATION:
                    SearchUser searchUser = new SearchUser(userList, bookList);
                    searchUser.LoadSearchingUserMenu();
                    break;

                case Constants.BOOK_REGISTER:
                    break;

                case Constants.BOOK_REVISE:
                    break;

                case Constants.BOOK_DELET:
                    break;

                case Constants.BOOK_SHOWALL:
                    break;

                case Constants.BOOK_SEARCH:
                    break;

                case Constants.MANGER_BACK:
                    Console.Clear();
                    FirstPage firstPage = new FirstPage(userList, bookList);
                    firstPage.ShowFirstPage();
                    break; 
            }
        }
    }
}
