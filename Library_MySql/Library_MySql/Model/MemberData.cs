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
            this.mySqlConnection = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8";
            this.connection = new MySqlConnection(this.mySqlConnection);
        }

        public void InsertMemberData(string id, string password, string name, string phoneNumber, string address, string book)
        {
            string insertQuery = "INSERT INTO member(Id,password,name,phoneNumber,address,book) VALUES(@id,@password,@name,@phoneNumber,@address,@book)";

            connection.Open();

            MySqlCommand insertCommand = new MySqlCommand();
            insertCommand.Connection = connection;
            insertCommand.CommandText = insertQuery;

            insertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@password", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@name", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@phoneNumber", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@address", MySqlDbType.VarChar, 45);
            insertCommand.Parameters.Add("@book", MySqlDbType.VarChar, 45);


            insertCommand.Parameters[0].Value = id;
            insertCommand.Parameters[1].Value = password;
            insertCommand.Parameters[2].Value = name;
            insertCommand.Parameters[3].Value = phoneNumber;
            insertCommand.Parameters[4].Value = address;
            insertCommand.Parameters[5].Value = book;

            insertCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void SelectMemberData()
        {
            string selectQuery = "SELECT * FROM member";


            connection.Open();

            MySqlCommand selectCommand = new MySqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = selectQuery;

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(selectQuery, connection);
            da.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine(String.Format("이름 : {0} 아이디 : {1} 주소 : {2}", row["name"], row["Id"], row["address"]));
            }

            connection.Close();
        }

        // 회원 데이터 변경
        public void UpdateMemberPhoneNumber(string Id, string phoneNumber)
        {
            string updateQuery = "UPDATE member SET phoneNumber=@phoneNumber WHERE Id=@Id";

            connection.Open();

            MySqlCommand updateCommand = new MySqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandText = updateQuery;

            updateCommand.Parameters.Add("@phoneNumber", MySqlDbType.VarChar, 20);
            updateCommand.Parameters.Add("@Id", MySqlDbType.VarChar, 10);

            updateCommand.Parameters[0].Value = phoneNumber;
            updateCommand.Parameters[1].Value = Id;

            updateCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateMemberAddress(string Id, string address)
        {
            string updateQuery = "UPDATE member SET address=@address WHERE Id=@Id";

            connection.Open();

            MySqlCommand updateCommand = new MySqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandText = updateQuery;

            updateCommand.Parameters.Add("@address", MySqlDbType.VarChar, 20);
            updateCommand.Parameters.Add("@Id", MySqlDbType.VarChar, 10);

            updateCommand.Parameters[0].Value = address;
            updateCommand.Parameters[1].Value = Id;

            updateCommand.ExecuteNonQuery();

            connection.Close();
        }

        // 책 데이터 삭제
        public void DeletMemberData(string id)
        {
            string deleteQuery = "DELETE FROM member WHERE id=@id;";

            connection.Open();

            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandText = deleteQuery;

            deleteCommand.Parameters.Add("@id", MySqlDbType.VarChar, 10);
            deleteCommand.Parameters[0].Value = id;

            deleteCommand.ExecuteNonQuery();

            connection.Close();
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

            return isFind;
        }
    }
}
