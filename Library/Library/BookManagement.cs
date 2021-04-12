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
            int bookMenu;
            const int enrollment = 1;
            const int modify = 2;
            const int search = 3;
            const int print = 4;
            const int rental = 5;
            const int bookreturn = 6;
            const int exit = 7;

            Console.Write("[1] : 도서 등록\n");
            Console.Write("[2] : 도서 수정\n");
            Console.Write("[3] : 도서 검색\n");
            Console.Write("[4] : 도서 출력\n");
            Console.Write("[5] : 도서 대여\n");
            Console.Write("[6] : 도서 반납\n");
            Console.Write("[7] : 뒤로 가기\n");
            bookMenu = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(0, 7);

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
            string bookTitle;
            bool isDone = false;

            Console.Write("찾으시는 책 제목을 입력해주세요 : ");
            bookTitle = Console.ReadLine();
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
                }
            }

            while (!isDone)
            {
                Console.WriteLine("");
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
}
