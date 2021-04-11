using System;
using System.Collections.Generic;
using System.Collections; 
using System.Text;

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
            return $"제목 : {Title}, 저자 : {Author}";
        }


    }

    public class BookManagement
    {
        public BookManagement()
        {

        }
        public void InsertBook()
        {
            int number;
            string title;
            string publisher;
            string author; 
            ArrayList bookList = new ArrayList();

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

            Console.WriteLine($"{bookList[0]}"); 
        }
    }

}


