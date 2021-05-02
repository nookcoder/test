using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace Library_MySql
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection =  new MySqlConnection("Server=localhost;Database=member;Uid=root;Pwd=0000;");

            string insertQuery = "INSERT INTO member_table(name,age) VALUES('name1','12')";

            try//예외 처리
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("인서트 성공");
                }
                else
                {
                    Console.WriteLine("인서트 실패");
                }

                command.CommandText = "UPDATE member_table SET name='name2' WHERE age=13]";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("실패");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
