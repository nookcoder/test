using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Model
{
    class BookData
    {
        private string mySqlConnection;
        private MySqlConnection connection;
        public BookData()
        {
            this.mySqlConnection = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8";
            this.connection = new MySqlConnection(this.mySqlConnection);
        }

        public void InsertMemberData(string bookId, string bookTitle, string bookPublisher, string bookAuthor, string bookPrice, string bookCount)
        {
            string insertQuery = "INSERT INTO member(bookId,bookTitle,bookPublisher,bookAuthor,bookPrice,bookCount) VALUES(@bookId,@bookTitle,@bookPublisher,@bookAuthor,@bookPrice,@bookCount)";

            connection.Open();

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@bookId", MySqlDbType.VarChar, 10);
            insertCommand.Parameters.Add("@bookTitle", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@bookPublisher", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@bookAuthor", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@bookPrice", MySqlDbType.VarChar, 7);
            insertCommand.Parameters.Add("@bookCount", MySqlDbType.VarChar, 7);


            insertCommand.Parameters[0].Value = bookId;
            insertCommand.Parameters[1].Value = bookTitle;
            insertCommand.Parameters[2].Value = bookPublisher;
            insertCommand.Parameters[3].Value = bookAuthor;
            insertCommand.Parameters[4].Value = bookPrice;
            insertCommand.Parameters[5].Value = bookCount;

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }

        public bool IsBookIdDuplication(string bookid)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;

            string selectQuert = "SELECT bookId FROM member";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            adapter.Fill(dataset, "book");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (bookid == row["bookId"].ToString())
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            return isFind;
        }

        public bool IsBookTitleDuplication(string bookTitle)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;
            string selectQuert = "SELECT bookTitle FROM member";
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            
            adapter.Fill(dataset, "book");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (bookTitle == row["bookId"].ToString())
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            return isFind;
        }


    }
}
