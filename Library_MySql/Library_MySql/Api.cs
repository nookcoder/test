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
            Console.SetWindowSize(150, 45);
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

                    Initialization.screen.PrintBar();
                    Console.WriteLine($"제목      : {title}");
                    Console.WriteLine($"저자      : {author}");
                    Console.WriteLine($"가격      : {price}");
                    Console.WriteLine($"출판사    : {publisher}");
                    Console.WriteLine($"출판 날짜 : {publishDate}");
                    Console.WriteLine($"ISBN      : {isbn}");
                    Console.WriteLine($"상세설명  : {description}");
                    Initialization.screen.PrintBar();

                    Console.WriteLine("\n");

                    bookCount++;
                }

                else
                {
                    break;
                }
            }

        }
    }
}
