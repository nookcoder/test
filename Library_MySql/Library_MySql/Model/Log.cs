using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        // 활동 내역 보여주는 함수 
        public void ShowRecord()
        {
            string selectQuery = "SELECT * FROM log";
            connection.Open();

            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                Initialization.screen.PrintMiniBar();
                if (reader["title"].ToString().Length == 0)
                {
                    Console.WriteLine($"  {reader["time"]} {reader["name"].ToString()} {reader["content"].ToString()}\n");
                }
                
                else
                {
                    Console.WriteLine($"  {reader["time"]} {reader["name"].ToString()} {reader["title"].ToString()} {reader["content"].ToString()}\n");
                }
                Initialization.screen.PrintMiniBar();
            }

            Initialization.screen.PrintNextProccess();
        }

        public void SaveRecord()
        {
            DataSet table = new DataSet();

            string selectQuery = "SELECT * FROM log";
            connection.Open();

            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = new MySqlCommand(selectQuery, connection);
            adapt.Fill(table);


            string[] rowString = new string[table.Tables[0].Rows.Count];
            int i = 0;
            foreach(DataRow row in table.Tables[0].Rows)
            {
                rowString[i] = row.ItemArray.GetValue(0).ToString() + ",";
                rowString[i] += row.ItemArray.GetValue(1).ToString() + ",";
                rowString[i] += row.ItemArray.GetValue(2).ToString();
                i++;
            }

            File.WriteAllLines(@"C:\Users\Username\Desktop", rowString);

       //     ExcelDocument workbook = new ExcelDocument(1);
        }

        public void ResetRecord()
        {
            string resetQuery = "DELETE FROM log";

            connection.Open();

            MySqlCommand resetCommand = new MySqlCommand();
            resetCommand.Connection = connection;
            resetCommand.CommandText = resetQuery;

            resetCommand.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine("  초기화가 완료되었습니다.");
            Initialization.screen.PrintNextProccess();
        }

    }
}