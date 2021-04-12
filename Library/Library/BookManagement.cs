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
                    SelectAll();
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


        // [1] 도서 추가 하기 
        // 도서 추가 하기 호출 함수. 
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

        // 책의 정보를 물어보는 함수. 
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


        // [3]원하는 도서를 찾는 함수.
        // 원하는 도서 출력하기 호출 함수.
        public void SelectOne()
        {
            string selectMenu;
            bool isDone = false;
            bool isError = true;

            BookPage bookPage = new BookPage();

            while (!isDone)
            {
                PrintGetTitle();
                selectMenu = PrintGetMoreSearch();
                Console.Clear();

                if (selectMenu == "1")
                {
                    Console.Clear();
                    bookPage.PrintBookMenu();
                }

                else if (selectMenu == "2")
                {
                    PrintBookMain();
                    isdone = true;
                }

                else
                {
                    isError = true;
                    while (isError)
                    {
                        bookPage.PrintError();
                        selectMenu = PrintGetMoreSearch();

                        if (selectMenu == "1" || selectMenu == "2")
                        {
                            isError = false;
                        }

                    }
                    Console.Clear();
                    if (selectMenu == "2")
                    {
                        isdone = true;
                        PrintBookMain();
                    }
                    else
                    {
                        bookPage.PrintBookMenu();
                    }
                }
            }

        }

        // 다시 검색하고 싶은 지 묻는 함수.
        public string PrintGetMoreSearch()
        {
            string selectMenu;
            Console.WriteLine("다른 책을 검색하시겠습니까 ?");
            Console.WriteLine("[1] 다시 검색");
            Console.WriteLine("[2] 종료 하기");
            selectMenu = Console.ReadLine();

            return selectMenu;
        }

        // 제목을 입력받아 해당 책이 있으면 출력하는 함수. 
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
                            Console.WriteLine(" ");
                            Console.WriteLine("대여여부 : 가능");
                        }

                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("대여여부 : 불가능");
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




        // [4] 전체 도서 출력하기 
        // 전체 도서 출력하기 호출 함수
        public void SelectAll()
        {
            BookPage bookPage = new BookPage();
            if (bookList.Count != 0)
            {
                for (int bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
                {
                    bookPage.PirntBar();
                    Console.WriteLine($"{bookList[bookListIndex]}");
                    bookPage.PirntBar();
                }
            }

            else
            {
                Console.Clear();
                bookPage.PrintBookMenu();
                Console.WriteLine(" ");
                Console.WriteLine("등록된 도서가 없습니다. ");
            }

            GoBack();
        }

        public void GoBack()
        {
            Console.WriteLine(" ");
            Console.Write("뒤로가려면 아무키나 눌러주세요.... ");
            Console.ReadKey();
            Console.Clear();
            PrintBookMain();
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

        public void PirntBar()
        {
            Console.WriteLine("--------------------");
        }

        public int GetBookMenuNumber()
        {
            int bookMenu;
            bookMenu = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(0, 7);

            return bookMenu;
        }

        // 에러 출력 함수 
        public void PrintError()
        {

            BookPage bookPage = new BookPage();

            Console.Clear();
            bookPage.PrintBookMenu();
            Console.WriteLine("");
            Console.WriteLine("잘못 입력하셨습니다.");
            Console.WriteLine("");

        }
    }
}


