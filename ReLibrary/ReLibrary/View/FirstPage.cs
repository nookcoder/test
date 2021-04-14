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
            Label label = new Label();
            PrintFirstPage();
        }

        public void PrintFirstPage()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("                    [1] 회원 입니다                         ");
            Console.WriteLine("                    [2] 관리자 입니다                       ");
            Console.WriteLine("============================================================");

        }
    }
}
