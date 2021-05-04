using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_MySql.Model;

namespace Library_MySql.Controll
{
    class Registration
    {
        private MemberData memberData;
        private BookData bookData;

        public Registration()
        {
            this.memberData = new MemberData();
            this.bookData = new BookData();
        }

        /// <summary>
        /// 회원 가입 관련 함수 
        /// </summary>
        public void RunRegisterMember()
        {
            string id, password, name, phoneNumber, address,age;

            Console.Clear();
            id = GetMemberid();
            password = GetMemberPassword();
            name = GetMemberName();
            phoneNumber = GetMemberPhoneNumber();
            address = GetMemberAddress();
            age = GetMemberAge();

            memberData.InsertMemberData(id, password, name, phoneNumber, address, age);

            Initialization.screen.PrintJoinSuccess();
            Console.ReadKey();
        }

        public string GetMemberid()
        {
            string idCheck;
            string id;
            Initialization.screen.PrintGetId();
            idCheck = Console.ReadLine();
            id = Initialization.exception.HandleGetId(idCheck,memberData);

            return id;
        }

        public string GetMemberPassword()
        {
            string passwordCheck;
            string password;
            Initialization.screen.PrintGetPassword();
            passwordCheck = Console.ReadLine();
            password = Initialization.exception.HandleGetPassword(passwordCheck);

            return password;
        }

        public string GetMemberName()
        {
            string nameCheck;
            string name;
            Initialization.screen.PrintGetName();
            nameCheck = Console.ReadLine();
            name = Initialization.exception.HandleGetName(nameCheck);

            return name;
        }

        public string GetMemberPhoneNumber()
        {
            string phoneNumberCheck;
            string phoneNumber;
            Initialization.screen.PrintGetPhoneNumber();
            phoneNumberCheck = Console.ReadLine();
            phoneNumber = Initialization.exception.HandleGetPhoneNumber(phoneNumberCheck,memberData);

            return phoneNumber;
        }

        public string GetMemberAddress()
        {
            string addressCheck;
            string address;
            Initialization.screen.PrintGetAddress();
            addressCheck = Console.ReadLine();
            address = Initialization.exception.HandleGetAddress(addressCheck);

            return address;
        }

        public string GetMemberAge()
        {
            string ageCheck;
            string age;
            Initialization.screen.PrintGetAge();
            ageCheck = Console.ReadLine();
            age = Initialization.exception.HandleGetAge(ageCheck);

            return ageCheck;
        }

        /// <summary>
        /// 도서 등록 관련 함수 
        /// </summary>
        public void RunRegisterBook()
        {
            string bookid;
            string bookTitle;
            string bookPublisher;
            string bookAuthor;
            string bookPrice;
            string bookCount;

            Console.Clear();
            bookid =  GetBookId();
            bookTitle =  GetBookTitle();
            bookPublisher = GetBookPublisher();
            bookAuthor = GetBookAuthor();
            bookPrice = GetBookPrice();
            bookCount = GetBookCount();

            bookData.InsertBookData(bookid, bookTitle, bookPublisher, bookAuthor, bookPrice, bookCount);

            Initialization.screen.PrintSuccessRegisterBook();
            Console.ReadKey();
        }

        public string GetBookId()
        {
            string bookIdCheck;
            string bookId;

            Initialization.screen.PrintGetBookId();
            bookIdCheck = Console.ReadLine();
            bookId = Initialization.exception.HandleGetBookUd(bookIdCheck, bookData);

            return bookId; 
        }

        public string GetBookTitle()
        {
            string bookTitleCheck;
            string bookTitle;

            Initialization.screen.PrintGetBookTitle();
            bookTitleCheck = Console.ReadLine();
            bookTitle = Initialization.exception.HandleGetBookTitle(bookTitleCheck, bookData);

            return bookTitle;
        }

        public string GetBookPublisher()
        {
            string bookPublisherCheck;
            string bookPublisher;

            Initialization.screen.PrintGetBookPublisher();
            bookPublisherCheck = Console.ReadLine();
            bookPublisher = Initialization.exception.HandleGetPublisher(bookPublisherCheck);

            return bookPublisher;
        }

        public string GetBookAuthor()
        {
            string bookAuthorCheck;
            string bookAuthor;

            Initialization.screen.PrintGetBookAuthor();
            bookAuthorCheck = Console.ReadLine();
            bookAuthor = Initialization.exception.HandleGetBookAuthor(bookAuthorCheck);

            return bookAuthor;
        }

        public string GetBookPrice()
        {
            string bookPriceCheck;
            string bookPrice;

            Initialization.screen.PrintGetBookPrice();
            bookPriceCheck = Console.ReadLine();
            bookPrice = Initialization.exception.HandleGetBookPrice(bookPriceCheck);

            return bookPrice;
        }

        public string GetBookCount()
        {
            string bookCountCheck;
            string bookCount;

            Initialization.screen.PrintGetBookCount();
            bookCountCheck = Console.ReadLine();
            bookCount = Initialization.exception.HandleGetBookCount(bookCountCheck);

            return bookCount;
        }
    }
}
