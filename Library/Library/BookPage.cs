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
            Console.Write("[1] : 도서 등록\n");
            Console.Write("[2] : 도서 수정\n");
            Console.Write("[3] : 도서 검색\n");
            Console.Write("[4] : 도서 출력\n");
            Console.Write("[5] : 도서 대여\n");
            Console.Write("[6] : 도서 반납\n");
            Console.Write("[7] : 뒤로 가기\n");
        }

        public void PirntBar()
        {
            Console.WriteLine(" -------------------- ");
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
            Console.WriteLine("| 잘못 입력하셨습니다.| ");
            PirntBar();

        }

        public void PrintUpdateSort(string text)
        {
            Console.Write($"수정할 {text}을 입력해주세요 : ");
        }
    }
}

