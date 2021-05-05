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
        private Inquiry Inquiry;

        public Borrowing()
        {
            this.Inquiry = new Inquiry();
        }

        public void BorrowBook(Inquiry inquiry, string id, BorrowingData borrowingData, BookData bookData)
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

        public void ReturnBook(string id, BorrowingData borrowingData)
        {
            bool isFind = false;
            string bookTitle;
            Console.Clear();
            using (MySqlConnection connection = new MySqlConnection(Initialization.connection))
            {
        
                connection.Open();
                string selectQuery = "SELECT * FROM borrowing WHERE id='" + id + "'";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.SetWindowSize(150, 45);
                Initialization.screen.PrintBar();
                Initialization.screen.PrintMemberLabel();
                while (reader.Read())
                {
                    ShowBorrowing(reader);
                }

                Console.WriteLine("\n");
                Initialization.screen.PrintBar();
                reader.Close();
                connection.Close();

                connection.Open();

                string sql = "SELECT * FROM borrowing WHERE id='" + id + "'";
                MySqlCommand borrowCommand = new MySqlCommand(sql, connection);
                MySqlDataReader borrowTable = borrowCommand.ExecuteReader();
                borrowTable.Read();

                Initialization.screen.PrintReturn();
                bookTitle = Console.ReadLine();
                if (borrowTable["book1"].ToString() == bookTitle)
                {
                    borrowingData.ReturnBook("1", id);
                    Initialization.screen.PrintReturnNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                else if(borrowTable["book2"].ToString() == bookTitle)
                {
                    borrowingData.ReturnBook("2", id);
                    Initialization.screen.PrintReturnNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                else if (borrowTable["book3"].ToString() == bookTitle)
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
        }
        

        /*Initialization.screen.PrintNext();
        Console.ReadKey();
        Console.SetWindowSize(60, 45);*/

    

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

    public void ShowBorrowing(MySqlDataReader reader)
    {
        int idLenght;
        int nameLenght;
        int phoneLength;
        int book1;
        int book1BorrowTIme;
        int book1ReturnTIme;
        int book2;
        int book2BorrowTIme;
        int book2ReturnTIme;
        int book3;
        int book3BorrowTIme;
        int book3ReturnTIme;

        idLenght = Initialization.exception.FindHangle(reader["Id"].ToString());
        nameLenght = Initialization.exception.FindHangle(reader["name"].ToString());
        phoneLength = Initialization.exception.FindHangle(reader["phoneNumber"].ToString());
        book1 = Initialization.exception.FindHangle(reader["book1"].ToString());
        book1BorrowTIme = Initialization.exception.FindHangle(reader["book1BorrowTIme"].ToString());
        book1ReturnTIme = Initialization.exception.FindHangle(reader["book1ReturnTIme"].ToString());
        book2 = Initialization.exception.FindHangle(reader["book2"].ToString());
        book2BorrowTIme = Initialization.exception.FindHangle(reader["book2BorrowTIme"].ToString());
        book2ReturnTIme = Initialization.exception.FindHangle(reader["book2ReturnTIme"].ToString());
        book3 = Initialization.exception.FindHangle(reader["book3"].ToString());
        book3BorrowTIme = Initialization.exception.FindHangle(reader["book3BorrowTIme"].ToString());
        book3ReturnTIme = Initialization.exception.FindHangle(reader["book3ReturnTIme"].ToString());

        Console.WriteLine("\n");
        Console.Write(String.Format(reader["Id"].ToString().PadRight(20 - reader["Id"].ToString().Length + idLenght, ' ')));
        Console.Write(String.Format(reader["name"].ToString().PadRight(26 - reader["name"].ToString().Length + nameLenght), ' '));
        Console.Write(String.Format(reader["phoneNumber"].ToString().PadRight(25 - reader["phoneNumber"].ToString().Length + phoneLength, ' ')));
        Console.WriteLine(String.Format(reader["book1"].ToString().PadRight(25 - reader["book1"].ToString().Length + book1, ' ')));
        Console.WriteLine(String.Format(reader["book1BorrowTime"].ToString().PadLeft(98 - reader["book1BorrowTime"].ToString().Length + book1BorrowTIme, ' ')));
        Console.WriteLine(String.Format(reader["book1ReturnTime"].ToString().PadLeft(98 - reader["book1ReturnTime"].ToString().Length + book1ReturnTIme, ' ')));
        Console.WriteLine(String.Format(reader["book2"].ToString().PadLeft(98 - reader["book2"].ToString().Length + book1, ' ')));
        Console.WriteLine(String.Format(reader["book2BorrowTime"].ToString().PadLeft(98 - reader["book2BorrowTime"].ToString().Length + book1BorrowTIme, ' ')));
        Console.WriteLine(String.Format(reader["book2ReturnTime"].ToString().PadLeft(98 - reader["book2ReturnTime"].ToString().Length + book1ReturnTIme, ' ')));
        Console.WriteLine(String.Format(reader["book3"].ToString().PadRight(98 - reader["book3"].ToString().Length + book1, ' ')));
        Console.WriteLine(String.Format(reader["book3BorrowTime"].ToString().PadLeft(98 - reader["book3BorrowTime"].ToString().Length + book1BorrowTIme, ' ')));
        Console.WriteLine(String.Format(reader["book3ReturnTime"].ToString().PadLeft(98 - reader["book3ReturnTime"].ToString().Length + book1ReturnTIme, ' ')));

    }
}
}
