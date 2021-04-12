using System;
using System.Collections.Generic;

namespace Library
{
    class BookManagement
    {

        public BookManagement()
        {

        }
        public int number;
        public string title;
        public string publisher;
        public string author;
        public bool isdone = false;
        List<Book> bookList = new List<Book>();

        public void PrintBookMain()
        {
            BookPage bookPage = new BookPage();
            const int enrollment = 1;
            const int modify = 2;
            const int search = 3;
            const int print = 4;
            const int rental = 5;
            const int bookreturn = 6;
            const int exit = 7;
            int bookMenu;

            bookPage.PrintBookMenu();
            bookMenu = bookPage.GetBookMenuNumber();

            switch (bookMenu)
            {
                case enrollment:
                    InsertBook();
                    break;

                case modify:
                    //ModifyBook(); 
                    break;

                case search:
                    SelectOne();
                    break;

                case print:
                    //SelectAll();
                    break;

                case rental:
                    //RentalBook();
                    break;

                case bookreturn:
                    //ReturnBook();
                    break;

                case exit:
                    //Exit(); 
                    break;
            }
        }

        public void SelectOne()
        {
            string selectMenu;
            bool isDone = false;

            while (!isDone)
            {
                BookPage bookPage = new BookPage();
                PrintGetTitle();
                selectMenu = PrintGetMoreSearch();
                Console.Clear();

                if (selectMenu == "1")
                {
                    bookPage.PrintBookMenu();
                    PrintGetTitle();
                    selectMenu = PrintGetMoreSearch();
                    Console.Clear();
                }

                else if (selectMenu == "2")
                {
                    PrintBookMain();
                    isdone = true;
                    break;
                }

                else
                {
                    ReviseErrorSelectOne();
                    Console.Clear();
                    bookPage.PrintBookMenu();
                }
            }

        }

        public string PrintGetMoreSearch()
        {
            string selectMenu;
            Console.WriteLine("다른 책을 검색하시겠습니까 ?");
            Console.WriteLine("[1] 다시 검색");
            Console.WriteLine("[2] 종료 하기");
            selectMenu = Console.ReadLine();
            
            return selectMenu;
        }

        public void PrintGetTitle()
        {
            string bookTitle;

            Console.Write("찾으시는 책 제목을 입력해주세요 : ");
            bookTitle = Console.ReadLine();

            if (bookList.Count != 0)
            {
                for (int bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
                {
                    if (bookList[bookListIndex].Title == bookTitle)
                    {
                        Console.WriteLine(bookList[bookListIndex]);
                        if (bookList[bookListIndex].IsOk)
                        {
                            Console.WriteLine("대여여부 : 가능");
                        }
                    }

                    else
                    {
                        Console.WriteLine("죄송하지만 해당 책은 존재하지 않습니다. ");
                        Console.WriteLine(" ");
                    }
                }
            }
            else
            {
                Console.WriteLine("죄송하지만 해당 책은 존재하지 않습니다. ");
                Console.WriteLine(" ");
            }
        }

        public void GetBookInfo()
        {
            Console.Write("도서 번호 : ");
            number = int.Parse(Console.ReadLine());
            Console.Write("책 제목 : ");
            title = Console.ReadLine();
            Console.Write("출판사 :  ");
            publisher = Console.ReadLine();
            Console.Write("작가 이름 : ");
            author = Console.ReadLine();
            bookList.Add(new Book(number, title, publisher, author, true));
            Console.WriteLine($"등록이 완료되었습니다.");
            Console.WriteLine(" ");
        }

        public void ReviseErrorSelectOne()
        {
            string selectMenu;
            bool isError = true;
            BookPage bookPage = new BookPage();

            while (isError)
            {
                Console.Clear();
                bookPage.PrintBookMenu();
                Console.WriteLine("");
                Console.WriteLine("잘못 입력하셨습니다.");
                Console.WriteLine("");

                selectMenu = PrintGetMoreSearch();

                if (selectMenu == "1" || selectMenu == "2")
                {
                    isError = false;
                }

            }
        }



        public void InsertBook()
        {
            string addition;
            GetBookInfo();
            while (!isdone)
            {
                Console.WriteLine("추가로 등록하시겠습니까 ?");
                Console.Write($"YES / NO : ");
                addition = Console.ReadLine();

                if (addition == "NO")
                {
                    isdone = true;
                    Console.WriteLine("도서 등록을 종료합니다. ");
                    Console.Clear();
                    PrintBookMain();

                }

                else if (addition == "YES")
                {
                    GetBookInfo();
                }
            }
        }
    }

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

        public int GetBookMenuNumber()
        {
            int bookMenu;
            bookMenu = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(0, 7);

            return bookMenu;
        }
    }
}


