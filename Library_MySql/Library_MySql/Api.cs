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
                //Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("ERROR 발생=" + status);
            }

            return text;
        }


    }
}
