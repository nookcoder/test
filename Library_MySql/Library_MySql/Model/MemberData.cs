using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library_MySql.Model
{
    class MemberData
    {

        private string mySqlConnection;
        private MySqlConnection connection;

        public MemberData()
        {
            this.mySqlConnection = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8;Allow User Variables=True";
            this.connection = new MySqlConnection(this.mySqlConnection);
        }

        public void InsertMemberData(string id, string password, string name, string phoneNumber, string address, string age)
        {
            string insertQuery = "INSERT INTO member(Id,password,name,phoneNumber,address,age) VALUES(@id,@password,@name,@phoneNumber,@address,@age)";

            connection.Open();

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@password", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@phoneNumber", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@address", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@age", MySqlDbType.VarChar, 45);


            insertCommand.Parameters[0].Value = id;
            insertCommand.Parameters[1].Value = password;
            insertCommand.Parameters[2].Value = name;
            insertCommand.Parameters[3].Value = phoneNumber;
            insertCommand.Parameters[4].Value = address;
            insertCommand.Parameters[5].Value = age;

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateMember(string Id,string target,string infomation)
        {
            string updateQuery = "UPDATE member SET "+ target +"=@"+ target + " WHERE Id=@Id";

            connection.Open();

            MySqlCommand updateCommand = new MySqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandText = updateQuery;

            updateCommand.Parameters.Add("@"+ target, MySqlDbType.VarChar, 20);
            updateCommand.Parameters.Add("@Id", MySqlDbType.VarChar, 10);

            updateCommand.Parameters[0].Value = infomation;
            updateCommand.Parameters[1].Value = Id;

            updateCommand.ExecuteNonQuery();

            connection.Close();
        }

        // 책 데이터 삭제
        public void DeletMemberData(string id)
        {
            string deleteQuery = "DELETE FROM member WHERE Id=@id;";

            connection.Open();

            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandText = deleteQuery;

            deleteCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);
            deleteCommand.Parameters[0].Value = id;

            deleteCommand.ExecuteNonQuery();

            connection.Close();
        }

        public bool IsDuplication(string id, string target)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;

            string selectQuert = "SELECT "+ target + " FROM member";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            adapter.Fill(dataset, "member");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (id == row["\""+target+"\""].ToString())
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            return isFind;
        }

        public bool IsMemberIdDuplication(string id)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;

            string selectQuert = "SELECT id FROM member";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            adapter.Fill(dataset, "member");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (id == row["id"].ToString())
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            return isFind;
        }

        public bool IsMemberIdContain(string id)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;

            string selectQuert = "SELECT id FROM borrowing";
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            adapter.Fill(dataset, "borrowing");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (row["id"].ToString().Contains(id))
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            return isFind;
        }

        public bool IsMemberPhoneNumberDuplication(string id)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;
            string selectQuert = "SELECT phoneNumber FROM member";

            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            adapter.Fill(dataset, "member");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (id == row["phoneNumber"].ToString())
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            connection.Close();

            return isFind;
        }

        public bool IsMemberPasswordDuplication(string id, string password)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;

            string selectQuery = "SELECT password FROM member WHERE Id =@id" ;

            connection.Open();

            MySqlCommand selectCommand = new MySqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = selectQuery;

            selectCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);
            selectCommand.Parameters[0].Value = id;

            MySqlDataReader reader = selectCommand.ExecuteReader();

            while(reader.Read())
            {
                if(password == reader["password"].ToString())
                {
                    isFind = Initialization.FIND;
                }
            }

            reader.Close();
            connection.Close();

            return isFind;
        }

        public void ShowMyData(string id)
        {
            string selecQuery = "SELECT * FROM member WHERE id='" + id + "'";

            Console.Clear();

            connection.Open();
            MySqlCommand selectCommand = new MySqlCommand(selecQuery, connection);
            MySqlDataReader reader = selectCommand.ExecuteReader();
            reader.Read();

            Initialization.screen.PrintMiniBar();
            Console.WriteLine($" 회원 아이디 : {reader["Id"].ToString()}");
            Console.WriteLine($" 회원 이름   : {reader["name"].ToString()}");
            Console.WriteLine($" 전화 번호   : {reader["phoneNumber"].ToString()}");
            Console.WriteLine($" 주소        : {reader["address"].ToString()}");
            Console.WriteLine($" 나이        : {reader["age"].ToString()}");
            Initialization.screen.PrintMiniBar();

            reader.Close();
            connection.Close();
        }
    }
}
