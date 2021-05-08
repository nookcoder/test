using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Model
{
    class Log
    {
        private string connectionQuery = Initialization.CONNECTION;
        private MySqlConnection connection;
        private Log() { this.connection = new MySqlConnection(connectionQuery); }

        private static Log log = null;
        public static Log Instance()
        {
            if (log == null)
            {
                log = new Log();
            }

            return log;
        }

        public void RecordWithBook(string name, string title, string content)
        {
            string insertQuery = "INSERT INTO log(time,name,title,content) VALUES(@time,@name,@title,@content)";

            connection.Open();

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@time", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@title", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@content", MySqlDbType.VarChar, 45);

            insertCommand.Parameters[0].Value = DateTime.Now.ToString("MM/dd/yyyy");
            insertCommand.Parameters[1].Value = "'" + name + "'님이";
            insertCommand.Parameters[2].Value = title + "을";
            insertCommand.Parameters[3].Value = content + "을 했습니다.";

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void RecordWithNoBook(string name, string content)
        {
            string insertQuery = "INSERT INTO log(time,name,content) VALUES(@time,@name,@content)";

            connection.Open();

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@time", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@content", MySqlDbType.VarChar, 45);

            insertCommand.Parameters[0].Value = DateTime.Now.ToString("MM/dd/yyyy");
            insertCommand.Parameters[1].Value = "'" + name + "'님이";
            insertCommand.Parameters[2].Value = content + "했습니다.";

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void RecordWithBookWithBookId(string name, string bookId, string content)
        {
            string insertQuery = "INSERT INTO log(time,name,content) VALUES(@time,@name,@content)";

            string bookName;
            string sql2 = "SELECT * FROM book WHERE bookId='" + bookId + "'";
            connection.Open();

            MySqlCommand bookCommand = new MySqlCommand(sql2, connection);
            MySqlDataReader bookTable = bookCommand.ExecuteReader();
            bookTable.Read();
            bookName = bookTable["bookTitle"].ToString();
            connection.Close();

            connection.Open();

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@time", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@title", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@content", MySqlDbType.VarChar, 45);

            insertCommand.Parameters[0].Value = DateTime.Now.ToString("MM/dd/yyyy");
            insertCommand.Parameters[1].Value = "'" + name + "'님이";
            insertCommand.Parameters[2].Value = bookName + "을";
            insertCommand.Parameters[3].Value = content + "했습니다.";

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }


    }
}
