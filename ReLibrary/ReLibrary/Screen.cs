using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLibrary.View
{
    class Screen
    {
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
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintFirstPage()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("                    [1] 회원 입니다                         ");
            Console.WriteLine("                    [2] 관리자 입니다                       ");
            Console.WriteLine("                    [3] 프로그램 종료                       ");
            Console.WriteLine("============================================================");
        }

        public void PrintUserLoginPage()
        {

            Console.WriteLine("============================================================");
            Console.WriteLine("                    [1] 로그인                              ");
            Console.WriteLine("                    [2] 회원가입                            ");
            Console.WriteLine("                    [3] 아이디/비밀번호 찾기                ");
            Console.WriteLine("                    [4] 탈퇴하기                            ");
            Console.WriteLine("                    [5] 뒤로 가기                           ");
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
