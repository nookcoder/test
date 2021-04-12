using System;
using System.Collections;

namespace Library
{
    public class Book
    {
        // 도서 정보 클래스. 

        public Book(string _number, string _title, string _publicher, string _author,bool _isOk)
        {
            this.Number = _number;
            this.Title = _title;
            this.Publisher = _publicher;
            this.Author = _author;
            this.IsOk = _isOk; // true 면 대여가능 
        }

        public bool IsOk
        {
            get;
            set;
        } 

        public string Number
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
            return $" 도서 번호 : {Number}\n" +
                   $" 책 제목   : {Title}\n" +
                   $" 출판사    : {Publisher}\n" +
                   $" 저자      : {Author}\n"; 
        }


    }

    
}


