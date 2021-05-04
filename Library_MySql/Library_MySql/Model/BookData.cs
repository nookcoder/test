﻿using MySql.Data.MySqlClient;
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


        // 도서 데이터베이스에 넣기 
        public void InsertBookData(string bookId, string bookTitle, string bookPublisher, string bookAuthor, string bookPrice, string bookCount)
        {
            string insertQuery = "INSERT INTO book(bookId,bookTitle,bookPublisher,bookAuthor,bookPrice,bookCount) VALUES(@bookId,@bookTitle,@bookPublisher,@bookAuthor,@bookPrice,@bookCount)";

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
        
        public void UpdateBookdate(string bookId ,string price)
        {
            string updateQuery = "UPDATE book SET bookPrice=@bookPrice WHERE bookId=@bookId";

            connection.Open();

            MySqlCommand updateCommand = new MySqlCommand();
            updateCommand.Connection = connection;
            updateCommand.CommandText = updateQuery;

            updateCommand.Parameters.Add("@bookPrice", MySqlDbType.VarChar, 20);
            updateCommand.Parameters.Add("@bookId", MySqlDbType.VarChar, 10);

            updateCommand.Parameters[0].Value = price;
            updateCommand.Parameters[1].Value = bookId;

            updateCommand.ExecuteNonQuery();

            connection.Close();
        }

        public void DeletBookdata(string bookid)
        {
            string deleteQuery = "DELETE FROM test WHERE bookId=@bookId";

            connection.Open();

            MySqlCommand deleteCommand = new MySqlCommand();
            deleteCommand.Connection = connection;
            deleteCommand.CommandText = deleteQuery;

            deleteCommand.Parameters.Clear();

            connection.Close();
        }

        // 중복되는 도서 번호가 있는 지 확인 
        public bool IsBookIdDuplication(string bookid)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;

            string selectQuert = "SELECT bookId FROM book";
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

        // 중복되는 도서명이 있는 지 확인 
        public bool IsBookTitleDuplication(string bookTitle)
        {
            DataSet dataset = new DataSet();
            bool isFind = Initialization.NOFIND;
            string selectQuert = "SELECT bookTitle FROM book";
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuert, connection);
            
            adapter.Fill(dataset, "book");

            if (dataset.Tables.Count > 0)
            {
                foreach (DataRow row in dataset.Tables[0].Rows)
                {
                    if (bookTitle == row["bookTitle"].ToString())
                    {
                        isFind = Initialization.FIND;
                    }
                }
            }

            return isFind;
        }


    }
}
