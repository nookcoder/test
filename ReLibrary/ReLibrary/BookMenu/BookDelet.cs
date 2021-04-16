using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Model;

namespace ReLibrary.Manager
{
    class BookDelet
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        public BookDelet(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }
        
        // 관리자가 도서 삭제 시 나올 화면 
        public void DeletBook()
        {
            string target;
            bool isFound = false;
            int bookindex = -1;

            Screen screen = new Screen();
            screen.PrintBookForDelet();
            target = Console.ReadLine();

            for(int index = 0; index < bookList.Count; index++)
            {
                if(bookList[index].Title == target || bookList[index].BookNumber == target)
                {
                    isFound = Constants.FOUND;
                    bookindex = index;
                }
            }

            if(isFound)
            {
                bookList.RemoveAt(bookindex);
                Console.WriteLine("                   삭제가 완료되었습니다.");
                Console.ReadKey();
                Console.Clear();
                ManagerMenu managerMenu = new ManagerMenu(userList,bookList);
                managerMenu.LoadMangerMenu();
            }

            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("                    해당 도서를 찾지 못하였습니다. ");
                Console.ReadKey();
                Console.Clear();
                ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
                managerMenu.LoadMangerMenu();
            }
        }
    }
}
