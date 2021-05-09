using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Model
{
    class BorrowingData
    {
        private MySqlConnection connection;

        public BorrowingData()
        {
            this.connection = new MySqlConnection(Initialization.CONNECTION);
        }

        public void InsertBorrowingData(string id,string name, string phoneNumber, string book1, string book1BorrowTime,string book1ReturnTime, string book2, string book2BorrowTime, string book2ReturnTime, string book3, string book3BorrowTime, string book3ReturnTime)
        {
            string insertQuery = "INSERT INTO borrowing VALUES(@id,@name,@phoneNumber,@book1,@book1BorrowTime,@book1ReturnTime,@book2,@book2BorrowTime,@book2ReturnTime,@book3,@book3BorrowTime,@book3ReturnTime)";

            connection.Open();
            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@phoneNumber", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book1", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book1BorrowTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book1ReturnTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book2", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book2BorrowTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book2ReturnTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book3", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book3BorrowTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book3ReturnTime", MySqlDbType.VarChar, 45);


            insertCommand.Parameters[0].Value = id;
            insertCommand.Parameters[1].Value = name;
            insertCommand.Parameters[2].Value = phoneNumber;
            insertCommand.Parameters[3].Value = book1;
            insertCommand.Parameters[4].Value = book1BorrowTime;
            insertCommand.Parameters[5].Value = book1ReturnTime;
            insertCommand.Parameters[6].Value = book2;
            insertCommand.Parameters[7].Value = book2BorrowTime;
            insertCommand.Parameters[8].Value = book2ReturnTime;
            insertCommand.Parameters[9].Value = book3;
            insertCommand.Parameters[10].Value = book3BorrowTime;
            insertCommand.Parameters[11].Value = book3ReturnTime;

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void BorrowBook(string bookname,string number, string id, string time1, string time2)
        {
            string insertQuery = "UPDATE borrowing SET book" + number + "=@book" + number + ",book" + number + "BorrowTime=@book" + number + "BorrowTime,book" + number + "ReturnTime = @book" + number + "ReturnTime WHERE id=@id";

            connection.Open();
            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@book"+number, MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book"+number+"BorrowTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book" + number + "ReturnTime", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);

            insertCommand.Parameters[0].Value = bookname;
            insertCommand.Parameters[1].Value = time1;
            insertCommand.Parameters[2].Value = time2;
            insertCommand.Parameters[3].Value = id;

            insertCommand.ExecuteNonQuery();

            connection.Close();

        }

        public void ReturnBook(string number,string id)
        {
            string updateQuery = "UPDATE borrowing SET book" + number + "=@book" + number + ",book" + number + "BorrowTime=@book" + number + "BorrowTime,book" + number + "ReturnTime = @book" + number + "ReturnTime WHERE id=@id";

            connection.Open();
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);

            updateCommand.Parameters.Add("@book" + number, MySqlDbType.VarChar, 45);
            updateCommand.Parameters.Add("@book" + number + "BorrowTime", MySqlDbType.VarChar, 45);
            updateCommand.Parameters.Add("@book" + number + "ReturnTime", MySqlDbType.VarChar, 45);
            updateCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);

            updateCommand.Parameters[0].Value = null;
            updateCommand.Parameters[1].Value = null;
            updateCommand.Parameters[2].Value = null;
            updateCommand.Parameters[3].Value = id;

            updateCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void DeletMemberData(string id)
        {
            string deleteQuery = "DELETE FROM borrowing WHERE Id='"+id+"'";

            connection.Open();

            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandText = deleteQuery;

            deleteCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
