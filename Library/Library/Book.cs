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

    
}


