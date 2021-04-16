using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLibrary.VO
{
    class BooksVO
    {
        private string bookNumber;
        private string title;
        private string author;
        private string publisher;
        public bool isOk; 

        public BooksVO(string bookNumber,string title, string author, string publisher)
        {
            this.bookNumber = bookNumber;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.isOk = true;
        }

        public string BookNumber
        {
            get { return bookNumber; }
            set { bookNumber = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        

        public override string ToString() => $"{bookNumber}  {title}  {author}  {publisher}\n"+
           "============================================================";
        

    }
}
