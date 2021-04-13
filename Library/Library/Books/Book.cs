using System;
using System.Collections;

namespace Library
{
    public class Book
    {
        // 도서 정보 클래스. 

        public Book(string _id, string _title, string _publicher, string _author,bool _isOk)
        {
            this.Id = _id;
            this.Title = _title;
            this.Publisher = _publicher;
            this.Author = _author;
            this.IsOk = _isOk; // true 면 대여가능 
        }

        public string Id
        {
            get;
            set;
        }
        public bool IsOk
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
            return $"\n"+
                   $"               도서 번호 : {Id}\n" +
                   $"               책 제목   : {Title}\n" +
                   $"               출판사    : {Publisher}\n" +
                   $"               저자      : {Author}\n"; 
        }


    }

    
}


