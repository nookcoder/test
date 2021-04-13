using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class BookPage
    {
        public BookPage()
        {

        }

        public void PrintBookMenu()
        {
            Console.WriteLine("    ==================================");
            Console.WriteLine("              [1] : 도서 등록");
            Console.WriteLine("              [2] : 도서 수정");
            Console.WriteLine("              [3] : 도서 검색");
            Console.WriteLine("              [4] : 도서 출력");
            Console.WriteLine("              [5] : 도서 대여");
            Console.WriteLine("              [6] : 도서 반납");
            Console.WriteLine("              [7] : 도서 삭제");
            Console.WriteLine("              [8] : 뒤로 가기");
            Console.WriteLine("    ==================================");

        }

        public void PirntBar()
        {
            Console.WriteLine("    ==================================");
        }

        public int GetBookMenuNumber()
        {
            int bookMenu;
            bookMenu = int.Parse(Console.ReadLine());
            Console.Clear();
            PrintBookMenu();

            return bookMenu;
        }

        // 에러 출력 함수 
        public void PrintError()
        {

            BookPage bookPage = new BookPage();

            Console.Clear();
            bookPage.PrintBookMenu();
            PirntBar();
            Console.WriteLine("           잘못 입력하셨습니다.");
            PirntBar();

        }

        public void PrintUpdateSort(string text)
        {
            Console.Write($"           수정할 {text}을 입력해주세요 : ");
        }

        public void PrintNoBook()
        {
            BookManagement bookManagement = new BookManagement();
            bookManagement.SetPrint();
            Console.WriteLine("      해당 도서는 존재하지 않습니다.");
        }
    }
}

