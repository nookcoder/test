using System;
using System.Collections.Generic;
using System.Collections; 
using System.Text;

namespace Library
{
    public class Book 
    {
        private string bookNumber; 
        private string bookTitle;
        private string bookPublisher;
        private string bookAuthor; 
        private bool isBookOk; // 책을 빌릴 수 있는 지 아닌 지 여부
        ArrayList booklist = new ArrayList(); 

        public Book(string _bookNumber, string _bookTitle, string _bookPublisher, string _bookAuthor, bool _isBookOk)
        {
            this.bookNumber = _bookNumber;
            this.bookTitle = _bookTitle;
            this.bookPublisher = _bookPublisher;
            this.bookAuthor = _bookAuthor;
            this.isBookOk = _isBookOk; 
        }

        public string getBookNumber()
        {
            return bookNumber;
        }

        public string getBookTitle()
        {
            return bookTitle; 
        }

        public string getPublisher()
        {
            return bookPublisher;
        }

        public string getAuthor()
        {
            return bookAuthor; 
        }

        public bool getIsBookOk()
        {
            return isBookOk; 
        }      
        
    }
}
