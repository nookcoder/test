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

        public void BorrowBook(Search inquiry, string id, BorrowingData borrowingData, BookData bookData)
        {
            using (MySqlConnection connection = new MySqlConnection(Initialization.connection))
            {
                string bookNumber;
                string bookName;
                string sql = "SELECT * FROM borrowing WHERE id='" + id + "'";
                bool isFind = false;

                inquiry.ShowBookyTitle();
                Console.SetWindowSize(150, 45);
                bookNumber = GetBorrowBookNumber();

                string findSql = "SELECT * FROM book";
                DataSet data = new DataSet();
                MySqlDataAdapter adpt = new MySqlDataAdapter(findSql, connection);
                adpt.Fill(data, "book");

                foreach (DataRow row in data.Tables[0].Rows)
                {
                    if (bookNumber == row["bookId"].ToString())
                    {
                        isFind = true;
                    }
                }

                if (isFind)
                {

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

                else
                {
                    Initialization.screen.PrintNoFindBook();
                    Console.ReadKey();
                }
            }

        }

        // 책 반납 함수 
        public bool ShowBookForReturn(string id)
        {
            bool isFind = true;
            Console.Clear();
            using (MySqlConnection connection = new MySqlConnection(Initialization.connection))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM borrowing WHERE id='" + id + "'";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();


                if (reader["book1"] == null && reader["book2"] == null && reader["book3"] == null)
                {
                    isFind = false;
                    Initialization.screen.PrintNoReturnBookNotice();
                    Initialization.screen.PrintNextProccess();
                }
                else
                {
                    Console.SetWindowSize(60, 45);
                    Initialization.screen.PrintMiniBar();
                    while (reader.Read())
                    {
                        if (reader["book1"] != null)
                        {
                            ShowBorrowing(reader, 1);
                        }

                        if (reader["book2"] != null)
                        {
                            ShowBorrowing(reader, 2);
                        }

                        if (reader["book3"] != null)
                        {
                            ShowBorrowing(reader, 3);
                        }
                    }
                    Console.WriteLine("\n");
                    Initialization.screen.PrintMiniBar();
                    reader.Close();
                    connection.Close();
                }
            }

            return isFind;
        }

        public void ReturnBook(string id,BorrowingData borrowingData)
        {
            string bookTitle;
            string sql = "SELECT * FROM borrowing WHERE id='" + id + "'";
         

            bookTitle = GetBookTitle();
            if (bookTitle != "q")
            {
                MySqlCommand borrowCommand = new MySqlCommand(sql, connection);
                MySqlDataReader borrowTable = borrowCommand.ExecuteReader();
                connection.Open();
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
