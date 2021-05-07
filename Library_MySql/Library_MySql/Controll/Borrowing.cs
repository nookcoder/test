using Library_MySql.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Borrowing
    {
        private Search Inquiry;
        private MySqlConnection connection;
        public Borrowing()
        {
            this.Inquiry = new Search();
            this.connection = new MySqlConnection(Initialization.connection);
        }

        // 도서관에 해당 책이 있는 지 확인해주는 함수
        public bool IsHaveBookInLibrary(string bookId)
        {
            string findQuery = "SELECT * FROM book";
            bool isHave = false;

            DataSet data = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(findQuery, connection);
            adapter.Fill(data, "book");

            foreach (DataRow row in data.Tables[0].Rows)
            {
                if (bookId == row["bookId"].ToString())
                {
                    isHave = true;
                }
            }

            return isHave;
        }

        // 회원이 그 도서를 갖고 있는 지 확인하는 함수 (중복 대출 불가) 
        public bool IsHaveBookWithMember(string id, string bookId)
        {
            string findQuery = "SELECT * FROM borrowing WHERE id='" + id + "'";
            string findQueryBook = "SELECT bookTitle FROM book WHERE bookId='" + bookId + "'";
            string bookTitle;
            bool isHave = false;

            connection.Open();
            MySqlCommand findCommand = new(findQueryBook, connection);
            MySqlDataReader dataReader = findCommand.ExecuteReader();
            dataReader.Read();
            bookTitle = dataReader["bookTitle"].ToString();
            connection.Close();
            DataSet data = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(findQuery, connection);
            adapter.Fill(data, "borrowing");

            foreach (DataRow row in data.Tables[0].Rows)
            {
                if (row["book1"].ToString() == bookTitle)
                {
                    isHave = true;
                }

                if (row["book2"].ToString() == bookTitle)
                {
                    isHave = true;
                }

                if (row["book3"].ToString() == bookTitle)
                {
                    isHave = true;
                }
            }
            return isHave;
        }

        // 도서 수량이 남아있는 지 확인 
        public bool IsHaveBook(string bookId)
        {
            string findQuery = "SELECT bookCount FROM book where bookId='" + bookId + "'";
            bool isOk = false;

            connection.Open();
            MySqlCommand findCommand = new(findQuery, connection);
            MySqlDataReader dataReader = findCommand.ExecuteReader();
            dataReader.Read();

            if (int.Parse(dataReader["bookCount"].ToString()) > 0)
            {
                isOk = true;
            }

            connection.Close();

            return isOk;
        }
        
        // 도서 대출 로직 
        public void BorrowBook(string id, string bookNumber, BorrowingData borrowingData, BookData bookData)
        {

            string bookName;
            string sql = "SELECT * FROM borrowing WHERE id='" + id + "'";
            string sql2 = "SELECT * FROM book WHERE bookId='" + bookNumber + "'";
            connection.Open();

            MySqlCommand bookCommand = new MySqlCommand(sql2, connection);
            MySqlDataReader bookTable = bookCommand.ExecuteReader();
            bookTable.Read();
            bookName = bookTable["bookTitle"].ToString();
            connection.Close();

            connection.Open();
            MySqlCommand borrowCommand = new MySqlCommand(sql, connection);
            MySqlDataReader borrowTable = borrowCommand.ExecuteReader();
            borrowTable.Read();

            if (borrowTable["book1"].ToString().Length == 0)
            {
                borrowingData.BorrowBook(bookName, "1", id);
                Initialization.screen.PrintBorrow();
            }

            else if (borrowTable["book2"].ToString().Length == 0)
            {
                borrowingData.BorrowBook(bookName, "2", id);
                Initialization.screen.PrintBorrow();
            }

            else if (borrowTable["book3"].ToString().Length == 0)
            {
                borrowingData.BorrowBook(bookName, "3", id);
                Initialization.screen.PrintBorrow();
            }

            else
            {
                Initialization.screen.PrintFailBorrowing();
                Initialization.screen.PrintNext();
                Console.ReadKey();
            }

            connection.Close();
        }

        // 도서 대출 메뉴 실행 시 실행되는 함수 
        public void RunBorrowing(string id, BorrowingData borrowingData, BookData bookData)
        {
            string bookIdCheck;
            string bookId;
            
            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetBorrowBookNumber();
            bookIdCheck = Console.ReadLine();
            bookId = Initialization.exception.HandleGetBookIdInModification(bookIdCheck);

            if (IsHaveBookInLibrary(bookId))
            {
                if (!IsHaveBookWithMember(id, bookId))
                {
                    if (IsHaveBook(bookId))
                    {
                        BorrowBook(id, bookId, borrowingData, bookData);
                        bookData.ModifyBookCountdate(bookId,"DOWN");
                    }

                    else 
                    {
                        Initialization.screen.PrintSorry();
                        Initialization.screen.PrintNextProccess();

                    }
                }

                else 
                { 
                    Initialization.screen.PrintAlreadyBorrowing();
                    Initialization.screen.PrintNextProccess();
                }
            }

            else 
            {
                Initialization.screen.PrintNoFindBook();
                Initialization.screen.PrintNext();
                Console.ReadKey();
            }
        }


        // 대출한 책 출력하는 함수 
        public bool ShowBookForReturn(string id)
        {
            bool isFind = true;
            Console.Clear();
            connection.Open();
            string selectQuery = "SELECT * FROM borrowing WHERE id='" + id + "'";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.SetWindowSize(60, 45);
            reader.Read();

            if (reader["book1"].ToString().Length == 0 && reader["book2"].ToString().Length == 0 && reader["book3"].ToString().Length == 0)
            {
                Initialization.screen.PrintNoReturnBookNotice();
                Initialization.screen.PrintNextProccess();
                isFind = false;
            }
            else
            {
                Initialization.screen.PrintMiniBar();
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
                Console.WriteLine("\n");
                Initialization.screen.PrintMiniBar();
            }

            reader.Close();
            connection.Close();

            return isFind;
        }

        // 도서 반납 함수 
        public void ReturnBook(string id, BorrowingData borrowingData)
        {
            string bookTitle;
            string sql = "SELECT * FROM borrowing WHERE id='" + id + "'";


            bookTitle = GetBookTitle();
            if (bookTitle != "q")
            {
                connection.Open();
                MySqlCommand borrowCommand = new MySqlCommand(sql, connection);
                MySqlDataReader borrowTable = borrowCommand.ExecuteReader();
                borrowTable.Read();

                if (borrowTable["book1"].ToString().Contains(bookTitle))
                {
                    borrowingData.ReturnBook("1", id);
                    Initialization.screen.PrintReturnNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                else if (borrowTable["book2"].ToString().Contains(bookTitle))
                {
                    borrowingData.ReturnBook("2", id);
                    Initialization.screen.PrintReturnNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                else if (borrowTable["book3"].ToString().Contains(bookTitle))
                {
                    borrowingData.ReturnBook("3", id);
                    Initialization.screen.PrintReturnNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                else
                {
                    Initialization.screen.PrintNoFindBook();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                connection.Close();
            }

            else { }

        }

        public string GetBookTitle()
        {
            string bookTitleCheck;
            string bookTItle;

            Initialization.screen.PrintExit();
            Initialization.screen.PrintReturn();
            Initialization.screen.PrintGetBookTitle();
            bookTitleCheck = Console.ReadLine();
            bookTItle = Initialization.exception.HandleGetTitle(bookTitleCheck);

            return bookTItle;
        }

        public string GetBorrowBookNumber()
        {
            string bookNumberCheck;
            string bookNumber;
            Initialization.screen.PrintGetBorrowBookNumber();
            bookNumberCheck = Console.ReadLine();
            bookNumber = Initialization.exception.HandleGetBookUdInBorrowing(bookNumberCheck);

            return bookNumber;
        }

        public string GetReturnBookNumber()
        {
            string bookNumberCheck;
            string bookNumber;
            Initialization.screen.PrintReturn();
            bookNumberCheck = Console.ReadLine();
            bookNumber = Initialization.exception.HandleGetBookUdInBorrowing(bookNumberCheck);

            return bookNumber;
        }

        public void ShowBorrowing(MySqlDataReader reader, int number)
        {
            Console.WriteLine("\n");
            Console.WriteLine("빌린 도서  : " + reader["book" + number].ToString());
            Console.WriteLine("대출일     : " + reader["book" + number + "BorrowTime"].ToString());
            Console.WriteLine("반납일     : " + reader["book" + number + "ReturnTime"].ToString());

        }
    }
}
