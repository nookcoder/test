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
                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM book";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    Console.SetWindowSize(150, 45);
                    Initialization.screen.PrintBar();
                    Initialization.screen.PrintBookLabel();

                    // 도서가 있으면 출력
                    while (reader.Read())
                    {
                        if (reader["bookTitle"].ToString().Contains(title))
                        {
                            ShowBook(reader);
                        }
                    }

                    Console.WriteLine("\n");
                    Initialization.screen.PrintBar();
                    reader.Close();
                    connection.Close();

                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }
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
                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM book";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    Console.SetWindowSize(150, 45);
                    Initialization.screen.PrintBar();
                    Initialization.screen.PrintBookLabel();

                    // 도서가 있으면 출력
                    while (reader.Read())
                    {
                        if (reader["bookPublisher"].ToString().Contains(publisher))
                        {
                            ShowBook(reader);
                        }
                    }

                    Console.WriteLine("\n");
                    Initialization.screen.PrintBar();
                    reader.Close();
                    connection.Close();

                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                    Console.SetWindowSize(60, 45);
                }
            }
        }

        // 도서 저자 검색 출력
        public void ShowBookByAuthor()
        {
            string author;

            author = GetPublisher();

            if (author == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM book";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    Console.SetWindowSize(150, 45);
                    Initialization.screen.PrintBar();
                    Initialization.screen.PrintBookLabel();

                    // 도서가 있으면 출력
                    while (reader.Read())
                    {
                        if (reader["bookAuthor"].ToString().Contains(author))
                        {
                            ShowBook(reader);
                        }
                    }

                    Console.WriteLine("\n");
                    Initialization.screen.PrintBar();
                    reader.Close();
                    connection.Close();

                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                    Console.SetWindowSize(60, 45);
                }
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

                Console.SetWindowSize(150, 45);
                Initialization.screen.PrintBar();
                Initialization.screen.PrintBookLabel();
                while (reader.Read())
                {
                    ShowBook(reader);
                }

                Console.WriteLine("\n");
                Initialization.screen.PrintBar();
                reader.Close();

                Initialization.screen.PrintNext();
                Console.ReadKey();
                Console.SetWindowSize(60, 45);
            }
        }

        public void ShowBookByNaverApi(Api api)
        {
            string title;
            string bookInformation;

            title = GetTitle();
            
            // 종료할 때 
            if (title == "q") { }
            
            // 검색어를 입력했을 때 
            else
            {
                bookInformation = api.GetBookInformation(title);
                Console.SetWindowSize(150, 45);
                Console.WriteLine(bookInformation);
                Initialization.screen.PrintNext();
                Console.ReadKey();
                Console.SetWindowSize(60, 45);
            }
        }

        // 도서 출력 함수 
        public void ShowBook(MySqlDataReader reader)
        {
            int titleLenght;
            int publisherLenght;
            int authorLength;

            titleLenght = Initialization.exception.FindHangle(reader["bookTitle"].ToString());
            publisherLenght = Initialization.exception.FindHangle(reader["bookPublisher"].ToString());
            authorLength = Initialization.exception.FindHangle(reader["bookAuthor"].ToString());


            Console.WriteLine("\n");
            Console.Write(String.Format(reader["bookId"].ToString().PadRight(10, ' ')));
            Console.Write(String.Format(reader["bookTitle"].ToString().PadRight(55 - reader["bookTitle"].ToString().Length + titleLenght), ' '));
            Console.Write(String.Format(reader["bookPublisher"].ToString().PadRight(25 - reader["bookPublisher"].ToString().Length + publisherLenght, ' ')));
            Console.Write(String.Format(reader["bookAuthor"].ToString().PadRight(40 - reader["bookAuthor"].ToString().Length + authorLength, ' ')));
            Console.Write(String.Format(reader["bookPrice"].ToString().PadRight(12, ' ')));
            Console.Write(String.Format(reader["bookCount"].ToString().PadRight(8, ' ')));
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
                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM member";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    Console.SetWindowSize(150, 45);
                    Initialization.screen.PrintBar();
                    Initialization.screen.PrintMemberLabel();

                    // 도서가 있으면 출력
                    while (reader.Read())
                    {
                        if (reader["name"].ToString().Contains(name))
                        {
                            ShowMember(reader);
                        }
                    }

                    Console.WriteLine("\n");
                    Initialization.screen.PrintBar();
                    reader.Close();
                    connection.Close();

                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                    Console.SetWindowSize(60, 45);
                }
            }
        }

        // 회원 나이 검색
        public void ShowMemberByAge()
        {
            string age;

            age = GetAge();

            if (age == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM member";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    Console.SetWindowSize(150, 45);
                    Initialization.screen.PrintBar();
                    Initialization.screen.PrintMemberLabel();

                    // 도서가 있으면 출력
                    while (reader.Read())
                    {
                        if (reader["age"].ToString().Contains(age))
                        {
                            ShowMember(reader);
                        }
                    }

                    Console.WriteLine("\n");
                    Initialization.screen.PrintBar();
                    reader.Close();
                    connection.Close();

                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                    Console.SetWindowSize(60, 45);
                }
            }
        }

        // 회원 주소 검색 
        public void ShowMemberByAddress()
        {
            string address;

            address = GetAddress();

            if (address == "q")
            {
                // 이전 메뉴로 돌아감 
            }

            else
            {
                Console.Clear();
                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM member";
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    Console.SetWindowSize(150, 45);
                    Initialization.screen.PrintBar();
                    Initialization.screen.PrintMemberLabel();

                    // 도서가 있으면 출력
                    while (reader.Read())
                    {
                        if (reader["address"].ToString().Contains(address))
                        {
                            ShowMember(reader);
                        }
                    }

                    Console.WriteLine("\n");
                    Initialization.screen.PrintBar();
                    reader.Close();
                    connection.Close();

                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                    Console.SetWindowSize(60, 45);
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
                string selectQuery = "SELECT * FROM member";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.SetWindowSize(150, 45);
                Initialization.screen.PrintBar();
                Initialization.screen.PrintMemberLabel();
                while (reader.Read())
                {
                    ShowMember(reader);
                }

                Console.WriteLine("\n");
                Initialization.screen.PrintBar();
                reader.Close();

                Initialization.screen.PrintNext();
                Console.ReadKey();
                Console.SetWindowSize(60, 45);
            }
        }

        public void ShowMember(MySqlDataReader reader)
        {
            int idLenght;
            int nameLenght;
            int phoneLength;
            int addressLength;

            idLenght = Initialization.exception.FindHangle(reader["Id"].ToString());
            nameLenght = Initialization.exception.FindHangle(reader["name"].ToString());
            phoneLength = Initialization.exception.FindHangle(reader["phoneNumber"].ToString());
            addressLength = Initialization.exception.FindHangle(reader["address"].ToString());


            Console.WriteLine("\n");
            Console.Write(String.Format(reader["Id"].ToString().PadRight(20 - reader["Id"].ToString().Length + idLenght, ' ')));
            Console.Write(String.Format(reader["name"].ToString().PadRight(26 - reader["name"].ToString().Length + nameLenght), ' '));
            Console.Write(String.Format(reader["phoneNumber"].ToString().PadRight(25 - reader["phoneNumber"].ToString().Length + phoneLength, ' ')));
            Console.Write(String.Format(reader["address"].ToString().PadRight(26 - reader["address"].ToString().Length + addressLength, ' ')));
            Console.Write(String.Format(reader["age"].ToString().PadRight(12, ' ')));
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
            Initialization.screen.PrintGetBookPublisher();
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

        public string GetAge()
        {
            string ageCheck;
            string age;
            Console.Clear();

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetInquiringAge();
            ageCheck = Console.ReadLine();
            age = Initialization.exception.HandleGetAgeInInquiry(ageCheck);

            return age;
        }

        public string GetAddress()
        {
            string addressCheck;
            string address;
            Console.Clear();

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetInquiringAddress();
            addressCheck = Console.ReadLine();
            address = Initialization.exception.HandleGetAddressInInquiry(addressCheck);

            return address;
        }
    }
}
