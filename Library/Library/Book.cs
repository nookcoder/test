using System;
using System.Collections;

namespace Library
{
    public class Book
    {
        // 도서 정보 클래스. 

        public Book(int _number, string _title, string _publicher, string _author)
        {
            this.Number = _number;
            this.Title = _title;
            this.Publisher = _publicher;
            this.Author = _author;
        }

        public int Number
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Publisher
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Title;
        }


    }

    public class BookManagement
    {
        public BookManagement()
        {

        }

        public int number;
        public string title;
        public string publisher;
        public string author;
        public string addition;
        public bool isdone = false;
        ArrayList bookList = new ArrayList();

        public void AskBookInfo()
        {
            Console.Write("도서 번호 : ");
            number = int.Parse(Console.ReadLine());
            Console.Write("책 제목 : ");
            title = Console.ReadLine();
            Console.Write("출판사 :  ");
            publisher = Console.ReadLine();
            Console.Write("작가 이름 : ");
            author = Console.ReadLine();
            Book book = new Book(number, title, publisher, author);
            bookList.Add(book);
            Console.WriteLine($"등록이 완료되었습니다.");
            Console.WriteLine(" "); 
        }

        public void InsertBook()
        {

            AskBookInfo();
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
                }

                else if (addition == "YES")
                {
                    AskBookInfo();
                }
            
            }
        }
    }

}


