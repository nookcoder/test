using System;
using System.Collections.Generic;

namespace Library
{
    class BookManagement
    {

        public BookManagement()
        {

        }
        private int bookListIndex;
        private string id;
        private string title;
        private string publisher;
        private string author;
        List<Book> bookList = new List<Book>();

        //!!!!!!!!!!!!!!!!! 도서등록에서 오류 수정하자!!!!!!!!!!!!!!!?

        // 도서관리 메뉴 처음 화면 출력. 
        public void PrintBookMain()
        {
            BookPage bookPage = new BookPage();
            const int Insert = 1;
            const int modify = 2;
            const int search = 3;
            const int print = 4;
            const int rental = 5;
            const int bookreturn = 6;
            const int exit = 7;
            bool isDone = false; 
            int bookMenu;

            while (!isDone)
            {
                // 메뉴 출력하기.
                bookPage.PrintBookMenu();

                // 메뉴 물어보기.
                Console.Write("메뉴 번호 입력 : ");
                bookMenu = bookPage.GetBookMenuNumber();
                switch (bookMenu)
                {
                    case Insert:
                        InsertBook();
                        break;

                    case modify:
                        ModifyBook();
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
                        isDone = true;
                        //Exit(); 
                        break;
                }
            }
        }

        // [1] 도서 추가 하기 
        // 도서 추가 하기 호출 함수. 
        public void InsertBook()
        {
            bool isDone = false;
            string addition;
            GetBookInfo();
            while (!isDone)
            {
                Console.WriteLine("추가로 등록하시겠습니까 ?");
                Console.Write($"YES / NO : ");
                addition = Console.ReadLine();

                if (addition == "NO")
                {
                    isDone = true;
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
            id = Console.ReadLine();
            Console.Write("책 제목 : ");
            title = Console.ReadLine();
            Console.Write("출판사 :  ");
            publisher = Console.ReadLine();
            Console.Write("작가 이름 : ");
            author = Console.ReadLine();
            bookList.Add(new Book(id, title, publisher, author, true));
            Console.WriteLine($"등록이 완료되었습니다.");
            Console.WriteLine(" ");
        }

        // [2] 도서 수정 하기 
        public void ModifyBook()
        {
            string bookId;
            string updatedTitle = null;
            string updatedPublisher = null;
            string updateddAuthor = null;

            string partString;
            int part;

            const int title = 1;
            const int publisher = 2;
            const int Author = 3;

            BookPage bookPage = new BookPage();

            PrintGetPart();
            Console.Write("번호 입력 : ");
            partString = Console.ReadLine();
            part = HandlePart(partString);

            Console.Clear();
            bookPage.PrintBookMenu();
            Console.Write("수정하고 도서 번호 : ");
            bookId = Console.ReadLine();
           
            switch (part)
            {
                case title:
                    UpdateInfo(bookId, updatedTitle);
                    break;

                case publisher:
                    UpdateInfo(bookId, updatedPublisher);
                    break;

                case Author:
                    UpdateInfo(bookId, updateddAuthor);
                    break;

            }

            Console.Clear();
            PrintBookMain();
        }

        public int HandlePart(string _part)
        {
            bool isError = true;
            const int RESET = 0;
            int intPart = RESET ;
            BookPage bookPage = new BookPage();

            while (isError)
            {
                if (_part == "1" || _part == "2" || _part == "3")
                {
                    isError = false;
                    intPart = int.Parse(_part);
                }

                else
                {
                    PrintGetPart();
                    Console.WriteLine("다시 입력해주세요 \n");
                    Console.Write("번호 입력 : ");
                    _part = Console.ReadLine();
                }
            }

            return intPart;
        }

        public void PrintGetPart()
        {
            BookPage bookPage = new BookPage();

            
            Console.Clear();
            bookPage.PrintBookMenu();
            bookPage.PirntBar();
            Console.Write("|    [1] 책 제목     |\n");
            Console.Write("|    [2] 출판사      |\n");
            Console.Write("|    [3] 저자        |\n");
            bookPage.PirntBar();
        }

        public void UpdateInfo(string _bookId, string update)
        {
            for (bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
            {
                if (bookList[bookListIndex].Id == _bookId)
                {
                    update = Console.ReadLine();
                    bookList[bookListIndex].Title = update;
                }
            }
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
                    isDone = true;
                }

                else
                {
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
                        isDone = true;
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
                for (bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
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
    }
}


