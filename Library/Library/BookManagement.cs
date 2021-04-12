using System;
using System.Collections.Generic;
using System.Threading;

namespace Library
{
    class BookManagement
    {

        public BookManagement()
        {

        }
        public int bookListIndex;
        List<Book> bookList = new List<Book>();

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
                Console.WriteLine("");

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
                        RentBook();
                        break;

                    case bookreturn:
                        ReturnBook();
                        break;

                    case exit:
                        isDone = true;
                        //Exit(); 
                        break;
                }
            }
        }



        // [1] 도서 추가 하기 
        // 도서 추가 하기 호출될 함수. 
        public void InsertBook()
        {
            BookPage bookPage = new BookPage();
            bool isDone = false;
            string addition;
            GetBookInfo();
            while (!isDone)
            {
                Console.WriteLine("  -------------------- ");
                Console.WriteLine(" 추가로 등록하시겠습니까 ?");
                Console.WriteLine("       [1] YES            ");
                Console.WriteLine("       [2] NO             ");
                Console.WriteLine("  -------------------- ");
                addition = Console.ReadLine();

                if (addition == "2")
                {
                    isDone = true;
                    Console.Clear();
                    PrintBookMain();
                }

                else if (addition == "1")
                {
                    SetPrint();
                    GetBookInfo();
                }
            }
        }

        // 책의 정보를 물어보는 함수. 
        public void GetBookInfo()
        {
            string id;
            string title;
            string publisher;
            string author;

            Console.WriteLine("");
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
        // 도서 수정 하기 호출될 함수.
        public void ModifyBook()
        {
            BookPage bookPage = new BookPage();
            string bookId;
            string updatedTitle = null;
            string updatedPublisher = null;
            string updateddAuthor = null;

            string partString;
            int part;

            const int title = 1;
            const int publisher = 2;
            const int Author = 3;

            bool isFound = false;

            PrintGetPart();
            Console.Write("번호 입력 : ");
            partString = Console.ReadLine();
            part = HandlePart(partString);

            SetPrint();

            Console.Write("수정할 도서 번호 : ");
            bookId = Console.ReadLine();
            isFound = FindBook(bookId);

            if (isFound)
            {
                switch (part)
                {
                    case title:
                        bookPage.PrintUpdateSort("책 제목");
                        UpdateInfo(bookId, updatedTitle);
                        break;

                    case publisher:
                        bookPage.PrintUpdateSort("출판사");
                        UpdateInfo(bookId, updatedPublisher);
                        break;

                    case Author:
                        bookPage.PrintUpdateSort("저자");
                        UpdateInfo(bookId, updateddAuthor);
                        break;

                }
            }

            else
            {
                SetPrint();
                Console.WriteLine("해당 도서가 존재하지 않습니다. 다시 시도 해주세요. ");
                GoBackBookMain();
            }

            Console.Clear();
            PrintBookMain();
        }

        // part 예외처리 
        public int HandlePart(string _part)
        {
            bool isError = true; // 에러가 있어서 실행된 함수이므로 초기 값 true;

            const int RESET = 0;
            int intPart = RESET;

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

            SetPrint();

            bookPage.PirntBar();
            Console.Write("|    [1] 책 제목     |\n");
            Console.Write("|    [2] 출판사      |\n");
            Console.Write("|    [3] 저자        |\n");
            bookPage.PirntBar();
        }

        // 도서 정보를 수정하는 함수.
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



        // [3]원하는 도서 출력하기
        // 원하는 도서 출력하기 호출될 함수.
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
            Console.WriteLine("");
            Console.WriteLine("[1] 다시 검색");
            Console.WriteLine("[2] 종료 하기");
            selectMenu = Console.ReadLine();

            return selectMenu;
        }

        // 제목을 입력받아 해당 책이 있으면 출력하는 함수. 
        public void PrintGetTitle()
        {
            string bookTitle;
            bool isFound = false;
            int bookIndex;

            Console.WriteLine("");
            Console.Write("찾으시는 책 제목을 입력해주세요 : ");
            bookTitle = Console.ReadLine();

            if (bookList.Count != 0)
            {
                isFound = FindBook(bookTitle);

                if (isFound)
                {
                    bookIndex = FindBookIndex(bookTitle);
                    Console.WriteLine(bookList[bookIndex]);
                    PrintRent(bookList[bookIndex].IsOk);

                }

                else
                {
                    SetPrint();
                    Console.WriteLine("죄송하지만 해당 책은 존재하지 않습니다. ");
                    Console.WriteLine(" ");
                }
            }

            else
            {
                SetPrint();
                Console.WriteLine("죄송하지만 해당 책은 존재하지 않습니다. ");
                Console.WriteLine(" ");
            }
        }



        // [4] 전체 도서 출력하기.
        // 전체 도서 출력하기 호출될 함수.
        public void SelectAll()
        {
            BookPage bookPage = new BookPage();
            if (bookList.Count != 0)
            {
                for (bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
                {
                    Console.WriteLine("");
                    bookPage.PirntBar();
                    Console.WriteLine($"{bookList[bookListIndex]}");
                    bookPage.PirntBar();
                }
            }

            else
            {
                SetPrint();

                Console.WriteLine("등록된 도서가 없습니다. ");
            }

            GoBackBookMain();
        }



        // [5] 도서 대여 하기
        // 도서 대여하기 호출될 함수.
        public void RentBook()
        {
            // 대여하기 -> 책 제목 입력 -> 대여 불가 여부 판단 -> 대여 성공 = 대여기간 // 실패 == 안내문구 
            string bookName;
            int bookIndex;
            bool isFound;

            SetPrint();
            Console.Write("책 제목 : ");
            bookName = Console.ReadLine();

            // 해당 도서가 목록에 있는 지 확인. 
            isFound = FindBook(bookName);

            // 해당 도서를 대여해줌.
            if (isFound)
            {
                bookIndex = FindBookIndex(bookName);
                if (bookList[bookIndex].IsOk)
                {
                    bookList[bookIndex].IsOk = false;
                    PrintRentSuccess(bookList[bookIndex].Title);
                }

                else
                {
                    Console.WriteLine("해당 도서는 대여가 불가능합니다");
                    GoBackBookMain();
                }
            }

            else
            {
                SetPrint();
                Console.WriteLine("해당 도서가 존재하지 않습니다.");
                GoBackBookMain();
            }
        }

        // 대여 성공 출력함수.
        public void PrintRentSuccess(string _bookTitle)
        {
            SetPrint();
            Console.WriteLine($"{_bookTitle}를 대여하셨습니다. \n");
            Console.WriteLine("반납 기한은 대여일 포함 7일입니다.\n");
            GoBack();
        }

        // 대여 여부 출력함수.
        public void PrintRent(bool _isOk)
        {
            if (_isOk)
            {
                Console.WriteLine("대여여부 : 가능");
            }

            else
            {
                Console.WriteLine("대여여부 : 불가능");
            }
        }



        // [6] 도서 반납하기 / 반납 기간 연장 
        public void ReturnBook()
        {
            string menu;
            bool isDone = false;

            while (!isDone)
            {
                SetPrint();
                Console.WriteLine(" [1] 반납 하기");
                Console.WriteLine(" [2] 시간 연장");
                Console.WriteLine(" [3] 뒤로 가기");

                menu = Console.ReadLine();

                if (menu == "1")
                {
                   
                }

                else if (menu == "2")
                {

                }

                else if (menu == "3")
                {
                    isDone = true;
                    Console.Clear();
                    PrintBookMain();

                }
            }
        }

        public void PrintReturn()
        {
            string bookName;
            int bookIndex;
            bool isFound;
           
            SetPrint();
            Console.Write("반납할 책 제목 : ");
            bookName = Console.ReadLine();
            isFound = FindBook(bookName);
            if (isFound)
            {
                bookIndex = FindBookIndex(bookName);
                Console.WriteLine($"{bookList[bookIndex].Title} 를 반납했습니다.");
                bookList[bookIndex].IsOk = true;
                Goback();
            }

            else
            {
                Console.WriteLine("해당 도서는 반납되었습니다. ");
                Goback();
            }
        }

        // 해당 도서가 목록에 있는 지 확인. 
        // 있으면 true, 없으면 false 반환.
        public bool FindBook(string _bookName)
        {
            for (bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
            {
                if (bookList[bookListIndex].Title == _bookName)
                {
                    return true;
                }
            }

            return false;
        }

        // 해당 도서의 인덱스 반환.
        public int FindBookIndex(string _bookName)
        {
            int _bookIndex = -1;

            for (bookListIndex = 0; bookListIndex < bookList.Count; bookListIndex++)
            {
                if (bookList[bookListIndex].Title == _bookName)
                {
                    _bookIndex = bookListIndex;
                }
            }

            return _bookIndex;
        }

        //뒤로가기 함수. 
        public void GoBackBookMain()
        {
            Console.WriteLine(" ");
            Console.Write("뒤로가려면 아무키나 눌러주세요.... ");
            Console.ReadKey();
            Console.Clear();
            PrintBookMain();
        }

        public void Goback()
        {
            Console.WriteLine("뒤로 가려면 아무키나 입력해주세요");
            Console.ReadKey();
        }
        
        // 로그가 쌓이지 않게 해주는 함수.
        public void SetPrint()
        {
            BookPage bookPage = new BookPage();

            Console.Clear();
            bookPage.PrintBookMenu();
            Console.WriteLine("");
        }
    }




}


