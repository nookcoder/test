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
        public Search()
        {

        }

        public string GetTitle()
        {
            string Title;

            Console.Clear();
            Initialization.screen.PrintGetBookTitle();
            Title = Console.ReadLine();

            return Title;

        }

        public void SearchByTitle()
        {
            string title;
            string connStr = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8";

            title = GetTitle();

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM book";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["bookTitle"].ToString().Contains(title))
                    {
                        Console.WriteLine($"{reader["bookTitle"]}");
                    }
                }
                reader.Close();
            }
        }
    }
}
