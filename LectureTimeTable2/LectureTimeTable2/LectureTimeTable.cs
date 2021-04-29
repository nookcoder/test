using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LectureTimeTable2
{
    class LectureTimeTable
    {
        static void Main(string[] args)
        {
            //Run run = new Run();
            //run.RunProgram();
            string a = "화 목 10:00~18:00";
            string b = "화 목 09:30~16:30, 화 18:00~19:00";
            string aDay = Regex.Replace(a, @"[^가-힣]", "");
            string bDay = Regex.Replace(b, @"[^가-힣]", "");
            string aTimeString = Regex.Replace(a, @"[^0-9]", "");
            string bTimeString = Regex.Replace(b, @"[^0-9]", "");
            int aTime = Convert.ToInt32(aTimeString);
            int bTime ;
            int bTime2;
            bTime = Convert.ToInt32(bTimeString.Substring(0, 8));
            bTime2 = Convert.ToInt32(bTimeString.Substring(8, 8));
            Console.WriteLine(aTime % 10000);
            Console.WriteLine(bTime % 10000);

            if (aTime/10000 > bTime/10000)
            {
                if (aTime / 10000 > bTime % 10000)
                {
                    Console.WriteLine("가능!!!!");
                }

                else
                {
                    Console.WriteLine("불가능!!!!!");
                }
            }

            else
            {
                if(aTime % 10000 < bTime / 10000)
                {
                    Console.WriteLine("가능!");
                }

                else
                {
                    Console.WriteLine("불가능!");
                }
            }

            Console.WriteLine(bTime2/10000);
        }
    }
}
