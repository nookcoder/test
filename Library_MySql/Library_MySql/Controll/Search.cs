using Library_MySql.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Search
    {
        string mySqlConnection;
        public Search()
        {
            this.mySqlConnection = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8";
        }

        // 도서 제목 검색 출력
        public void ShowBookyTitle()
        {
            string title;

            title = GetTitle();

            if (title == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                ShowBookInfo("title", title);
            }
        }

        // 도서 출판사 검색 출력
        public void ShowBookByPublisher()
        {
            string publisher;

            publisher = GetPublisher();

            if (publisher == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                ShowBookInfo("publisher", publisher);
            }
        }

        // 도서 저자 검색 출력
        public void ShowBookByAuthor()
        {
            string author;

            author = GetAuthor();

            if (author == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                ShowBookInfo("author", author);
            }
        }

        // 도서 전체 출력
        public void ShowAllBook()
        {
            Console.Clear();
            using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM book";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Initialization.screen.PrintBar();
                    ShowBook(reader);
                    Initialization.screen.PrintBar();
                    Console.WriteLine("\n");
                }

                reader.Close();

                Initialization.screen.PrintNext();
                Console.ReadKey();
            }
        }

        // 네이버에서 검색하기 
        public void ShowBookByNaverApi(Api api)
        {
            string title;
            string bookInformation;
            int count;

            title = GetTitle();
            count = Convert.ToInt32(Console.ReadLine());

            // 종료할 때 
            if (title == "q") { }

            // 검색어를 입력했을 때 
            else
            {

                bookInformation = api.GetBookInformation(title);
                api.PrintBookInformation(bookInformation, count);

                Initialization.screen.PrintNext();
                Console.ReadKey();
            }
        }

        // 도서 출력 함수 
        public void ShowBook(MySqlDataReader reader)
        {
            Console.WriteLine($"도서 번호 : {reader["bookId"].ToString()}");
            Console.WriteLine($"도서 제목 : {reader["bookTitle"].ToString()}");
            Console.WriteLine($"출판사    : {reader["bookPublisher"].ToString()}");
            Console.WriteLine($"저자      : {reader["bookAuthor"]}");
            Console.WriteLine($"도서 가격 : {reader["bookPrice"]}원");
            Console.WriteLine($"도서 권수 : {reader["bookCount"].ToString()}권");

        }

        // 회원 이름 검색
        public void ShowMemberByName()
        {
            string name;

            name = GetName();

            if (name == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                ShowMemberInfo("name", name);
            }
        }

        // 회원 아이디 검색 
        public void ShowMemberById(MemberData memberData)
        {
            string id;

            id = GetId();

            if (id != "q")
            {
                if (memberData.IsMemberIdContain(id))
                {
                    Console.Clear();
                    ShowMemberInfo("id", id);
                }

                else 
                { 
                    Initialization.screen.PrintNoFIndMember();
                    Initialization.screen.PrintNextProccess();
                }
            }
        }

        // 회원 전체 출력
        public void ShowAllMember()
        {

            Console.Clear();
            using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM borrowing";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Initialization.screen.PrintMiniBar();
                    ShowMember(reader);
                    Initialization.screen.PrintMiniBar();
                    Console.WriteLine("\n");
                }
                reader.Close();

                Initialization.screen.PrintNext();
                Console.ReadKey();
            }
        }

        public void ShowMember(MySqlDataReader reader)
        {
            Console.WriteLine($"회원 아이디 : {reader["Id"].ToString()}");
            Console.WriteLine($"회원 이름   : {reader["name"].ToString()}");
            Console.WriteLine($"전화 번호   : {reader["phoneNumber"].ToString()}");

            if (reader["book1"].ToString().Length != 0)
            {
                ShowBorrowing(reader, 1);
            }


            if (reader["book2"].ToString().Length != 0)
            {
                ShowBorrowing(reader, 2);
            }


            if (reader["book3"].ToString().Length != 0)
            {
                ShowBorrowing(reader, 3);
            }
        }

        public void ShowBorrowing(MySqlDataReader reader, int number)
        {
            Console.WriteLine("\n");
            Console.WriteLine("빌린 도서  : " + reader["book" + number].ToString());
            Console.WriteLine("대출일     : " + reader["book" + number + "BorrowTime"].ToString());
            Console.WriteLine("반납일     : " + reader["book" + number + "ReturnTime"].ToString());
        }

        public string GetTitle()
        {
            string titleCheck;
            string title;
            Console.Clear();
            Initialization.screen.PrintGetBookTitle();
            titleCheck = Console.ReadLine();
            title = Initialization.exception.HandleGetTitle(titleCheck);

            return title;
        }

        public string GetPublisher()
        {
            string publisherCheck;
            string publisher;
            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetBookPublisher();
            publisherCheck = Console.ReadLine();
            publisher = Initialization.exception.HandleGetPublisherInInquiry(publisherCheck);

            return publisher;
        }

        public string GetAuthor()
        {
            string authorCheck;
            string author;
            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetBookAuthor();
            authorCheck = Console.ReadLine();
            author = Initialization.exception.HandleGetPublisherInInquiry(authorCheck);

            return author;
        }

        public string GetName()
        {
            string nameCheck;
            string name;
            Console.Clear();

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetInquiringName();
            nameCheck = Console.ReadLine();
            name = Initialization.exception.HandleGetNameInInquiry(nameCheck);

            return name;
        }

        public string GetId()
        {
            string idCheck;
            string id;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetIdForSearch();
            idCheck = Console.ReadLine();
            id = Initialization.exception.HandleGetIdForSearch(idCheck);

            return id;
        }

        public void ShowMemberInfo(string type, string input)
        {
            using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM borrowing";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[type].ToString().Contains(input))
                    {
                        Initialization.screen.PrintMiniBar();
                        ShowMember(reader);
                        Initialization.screen.PrintMiniBar();
                        Console.WriteLine("\n");
                    }
                }
                reader.Close();
                connection.Close();
            }
            Initialization.screen.PrintNext();
            Console.ReadKey();
        }

        public void ShowBookInfo(string type,string input)
        {
            using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM book";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                // 도서가 있으면 출력
                while (reader.Read())
                {
                    if (reader[type].ToString().Contains(input))
                    {
                        Initialization.screen.PrintBar();
                        ShowBook(reader);
                        Initialization.screen.PrintBar();
                        Console.WriteLine("\n");
                    }
                }

                reader.Close();
                connection.Close();

                Initialization.screen.PrintNext();
                Console.ReadKey();
            }
        }
    }
}
