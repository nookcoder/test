using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLibrary.View
{
    class Common
    {
        public Common()
        {
            PrintLabel();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintLabel()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("");
            Console.WriteLine("============================================================");
            Console.WriteLine(" ㅁ       ㅁ ㅁㅁㅁㅁ ㅁㅁㅁㅁ    ㅁㅁ    ㅁㅁㅁㅁ ㅁ    ㅁ ");
            Console.WriteLine(" ㅁ       ㅁ ㅁ    ㅁ ㅁ    ㅁ   ㅁ  ㅁ   ㅁ    ㅁ   ㅁ ㅁ  ");
            Console.WriteLine(" ㅁ       ㅁ ㅁㅁㅁㅁ ㅁㅁㅁ    ㅁㅁㅁㅁ  ㅁㅁㅁ       ㅁ   ");
            Console.WriteLine(" ㅁ       ㅁ ㅁ    ㅁ ㅁ    ㅁ ㅁ      ㅁ ㅁ    ㅁ     ㅁ   ");
            Console.WriteLine(" ㅁㅁㅁㅁ ㅁ ㅁㅁㅁㅁ ㅁ    ㅁ ㅁ      ㅁ ㅁ     ㅁ    ㅁ   ");
            Console.WriteLine("============================================================");
        }

        public void PrintInput()
        {
            Console.Write("                       입력 : ");
        }

        public void PrintPageError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    잘못 입력했습니다                       ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
