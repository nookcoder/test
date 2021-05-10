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
        private BorrowingData borrowingData;

        public Registration()
        {
            this.memberData = new MemberData();
            this.bookData = new BookData();
            this.borrowingData = new BorrowingData();
        }

        /// <summary>
        /// 회원 가입 관련 함수 
        /// </summary>
        // 으아ㅏ... 인터페이스? 그거 써보려 했는데 어떻게 적용시키는 건지 이해가 잘 안가요..ㅠ
        public void RunRegisterMember()
        {
            string id, password, name, phoneNumber, address, age;

            Console.Clear();
            Initialization.screen.PrintGetId();
            id = GetWithMemberData(Initialization.exception.HandleGetId);

            if (id != "q")
            {
                Initialization.screen.PrintGetPassword();
                password = Get(Initialization.exception.HandleGetPassword);

                if (password != "q")
                {
                    Initialization.screen.PrintGetName();
                    name = Get(Initialization.exception.HandleGetName);

                    if (name != "q")
                    {
                        Initialization.screen.PrintGetPhoneNumber();
                        phoneNumber = GetWithMemberData(Initialization.exception.HandleGetPhoneNumber);

                        if (phoneNumber != "q")
                        {
                            Initialization.screen.PrintGetAddress();
                            address = Get(Initialization.exception.HandleGetAddress);

                            if (address != "q")
                            {
                                Initialization.screen.PrintGetAge();
                                age = Get(Initialization.exception.HandleGetAge);

                                if (age != "q")
                                {
                                    memberData.InsertMemberData(id, password, name, phoneNumber, address, age);
                                    borrowingData.InsertBorrowingData(id, name, phoneNumber, null, null, null, null, null, null, null, null, null);
                                    Initialization.log.RecordWithNoBook(name, "회원가입");
                                    Initialization.screen.PrintJoinSuccess();
                                }
                            }
                        }
                    }
                }
            }
            Initialization.screen.PrintNextProccess();
        }

        /// <summary>
        /// 도서 등록 관련 함수 
        /// </summar>
        
        public void RunRegisterFromSearch(Api api,BookData bookData)
        {
            string title;
            string information;
            string isbe; 
            int count;

            Console.Clear();
            Initialization.screen.PrintExit();

            Initialization.screen.PrintGetTitleForShow();
            title = Get(Initialization.exception.HandleGetTitleForShow); 
           
            Initialization.screen.PrintGetCountForShow();
            count = Convert.ToInt32(Get(Initialization.exception.HandleGetCountForShow));

            information = api.GetBookInformation(title);
            api.PrintBookInformation(information, count);
            isbe = GetIsbn();
            api.InsertBookFromNaver(information,isbe,bookData);
        }

        // 도서 직접 등록 
        public void RunRegisterBook()
        {
            string bookid;
            string bookTitle;
            string bookPublisher;
            string bookAuthor;
            string bookPrice;
            string bookCount;

            Console.Clear();
            Initialization.screen.PrintGetBookId();
            bookid = GetWithBookData(Initialization.exception.HandleGetBookUd);

            if (bookid != "q")
            {
                Initialization.screen.PrintGetBookTitle();
                bookTitle = GetWithBookData(Initialization.exception.HandleGetBookTitle);
                    
                if(bookTitle != "q")
                {
                    Initialization.screen.PrintGetBookPublisher();
                    bookPublisher = Get(Initialization.exception.HandleGetPublisher);

                    if(bookPublisher != "q")
                    {
                        Initialization.screen.PrintGetBookAuthor();
                        bookAuthor = Get(Initialization.exception.HandleGetBookAuthor);
                        
                        if(bookAuthor != "q")
                        {
                            Initialization.screen.PrintGetBookPrice();
                            bookPrice = Get(Initialization.exception.HandleGetBookPrice);

                            if(bookPrice != "q")
                            {
                                Initialization.screen.PrintGetBookCount();
                                bookCount = Get(Initialization.exception.HandleGetBookCount);
                                Initialization.log.RecordWithBook("관리자", bookTitle, "등록");

                                bookData.InsertBookData(bookid, bookTitle, bookPublisher, bookAuthor, bookPrice, bookCount);

                                Initialization.screen.PrintSuccessRegisterBook();
                            }
                        }
                    }
                }
            }

            Initialization.screen.PrintNextProccess();
            Console.ReadKey();
        }

        // 무언가를 얻어올 때 쓰는 함수들
        public string Get(Func<string, string> MethodName)
        {
            string str;
            str = Console.ReadLine();
            str = MethodName(str);

            return str;
        }

        public string GetWithMemberData(Func<string, MemberData, string> MethodName)
        {
            string str;
            MemberData member = new MemberData();
            str = Console.ReadLine();
            str = MethodName(str, member);

            return str;
        }

        public string GetWithBookData(Func<string, BookData, string> MethodName)
        {
            string str;
            BookData book = new BookData();
            str = Console.ReadLine();
            str = MethodName(str, book);

            return str;
        }

        public string GetIsbn()
        {
            string isbn;
            Initialization.screen.PrintIsbn();
            isbn = Console.ReadLine();

            return isbn;
        }

    }
}
