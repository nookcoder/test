using System;
using System.Data;
using MySql.Data.MySqlClient;
using Library_MySql.Controll;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using Library_MySql.Model;

namespace Library_MySql
{
    class Api
    {

        public Api()
        {
        }

        public string GetBookInformation(string target)
        {
            string query = target;
            string url = Initialization.NAVERURL + query;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-id", Initialization.CLIENTID);
            request.Headers.Add("X-Naver-Client-Secret", Initialization.CLIENTPASSWORD);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            string text = null;

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                text = reader.ReadToEnd();
            }

            else
            {
                Console.WriteLine("ERROR 발생=" + status);
            }

            return text;
        }

        public void PrintBookInformation(string text, int count)
        {
            string title;
            string author;
            string price;
            string publisher;
            string publishDate;
            int bookCount = 0;
            string isbn;
            string description;

            JObject jobject = JObject.Parse(text);
            JToken jToken = jobject["items"];

            foreach (JToken items in jToken)
            {
                if (bookCount != count)
                {
                    title = items["title"].ToString();
                    author = items["author"].ToString();
                    price = items["price"].ToString();
                    publisher = items["publisher"].ToString();
                    publishDate = items["pubdate"].ToString();
                    isbn = items["isbn"].ToString();
                    description = items["description"].ToString();

                    Initialization.screen.PrintMiniBar();
                    Console.WriteLine($"제목      : {title}");
                    Console.WriteLine($"저자      : {author}");
                    Console.WriteLine($"가격      : {price}원");
                    Console.WriteLine($"출판사    : {publisher}");
                    Console.WriteLine($"출판 날짜 : {publishDate}");
                    Console.WriteLine($"ISBN      : {isbn}");
                    Console.WriteLine($"상세설명  : {description}");
                    Initialization.screen.PrintMiniBar();

                    Console.WriteLine("\n");

                    bookCount++;
                }

                else
                {
                    break;
                }
            }
        }

        public void InsertBookFromNaver(string text, string isbn, BookData bookData)
        {
            JObject jobject = JObject.Parse(text);
            JToken jToken = jobject["items"];
            bool isFind = false;
            string bookId;
            string bookCount;
            foreach (JToken items in jToken)
            {
                if (isbn == items["isbn"].ToString())
                {
                    Initialization.screen.PrintAskInfo();
                    bookId = GetBookId(bookData);
                    bookCount = GetBookCount();
                    bookData.InsertBookData(bookId, items["title"].ToString(), items["publisher"].ToString(), items["author"].ToString(), items["price"].ToString(), bookCount);
                    Initialization.log.RecordWithBook("관리자", items["title"].ToString(), "등록");
                    isFind = true;
                }
            }

            if(!isFind)
            {
                Initialization.screen.PrintNoFindBook();
                Initialization.screen.PrintNextProccess();
            }

        }

        public string GetBookId(BookData bookData)
        {
            string bookId;
            Initialization.screen.PrintGetBookId();
            bookId = Console.ReadLine();
            bookId = Initialization.exception.HandleGetBookUd(bookId, bookData);

            return bookId;
        }

        public string GetBookCount()
        {
            string bookCount;
            Initialization.screen.PrintGetBookCount();
            bookCount = Console.ReadLine();
            bookCount = Initialization.exception.HandleGetBookCount(bookCount);

            return bookCount;
        }
    }
}
