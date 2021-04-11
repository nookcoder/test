using System;
using System.Collections.Generic;
using System.Collections; 
using System.Text;

namespace Library
{
    public class Book 
    {
        private string number; 
        private string title;
        private string publisher;
        private string author; 
        private bool isBookOk; // 책을 빌릴 수 있는 지 아닌 지 여부
        ArrayList booklist = new ArrayList(); 

        public Book()
        {
        
        }

        public string Number 
        {
            get { return number; }
            set { number = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public string Author
        {
            get { return number; }
            set { number = value; }
        }

        public bool IsBookOk
        {
            get { return isBookOk; }
            set { isBookOk = value;   }

        }
        public string getBookNumber()
        {
            return number;
        }

        public string getBookTitle()
        {
            return title; 
        }

        public string getPublisher()
        {
            return publisher;
        }

        public string getAuthor()
        {
            return author; 
        }

        public bool getIsBookOk()
        {
            return isBookOk; 
        }      
        
    }


}
