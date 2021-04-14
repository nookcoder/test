using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLibrary.View
{
    public class FirstPage
    {
        public FirstPage()
        {
            PrintFirstPage();
        }

        public void PrintFirstPage()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("                    [1] 회원 입니다                         ");
            Console.WriteLine("                    [2] 관리자 입니다                       ");
            Console.WriteLine("                    [3] 프로그램 종료                       ");
            Console.WriteLine("============================================================");
        }
    }
}
