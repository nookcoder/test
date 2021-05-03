using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql
{
    class Screen
    {
        private Screen() { }

        private static Screen screen = null;

        public static Screen Instance()
        {
            if (screen == null)
            {
                screen = new Screen();
            }

            return screen;
        }

        public void PrintLabel()
        {
            Console.SetWindowSize(60, 45);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■          ■■■■■  ■■■  ■■          ■  ■■■");
            Console.WriteLine("■■■  ■■■■■■■■■  ■■■  ■■■■■■  ■  ■■■");
            Console.WriteLine("■■■  ■■■■■■■■■  ■■■  ■■■  ■■■■  ■■■");
            Console.WriteLine("■■■          ■■■■    ■      ■■                ■■");
            Console.WriteLine("■■■■■  ■■■■■  ■  ■■■  ■■■■■■■■  ■■■");
            Console.WriteLine("■■■■■  ■■■■■  ■■  ■■  ■■■  ■■■■■■■■");
            Console.WriteLine("■■              ■■  ■■  ■■  ■■■            ■■■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }
        public void PrintInitalMenu()
        {
            Console.WriteLine(new String(' ', 20) + "[1] 회원 접속");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 회원 가입");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String(' ', 20) + "[3] 관리자 접속");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String(' ', 20) + "[4] 종료 하기");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 회원가입 관련 화면 
        /// </summary>
        public void PrintGetId()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  아이디(영어,숫자만) : ");
        }

        public void PrintGetPassword()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  비밀번호(영어,숫자만) : ");
        }

        public void PrintGetName()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  이름 : ");
        }

        public void PrintGetPhoneNumber()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  전화번호('-' 제외) : ");
        }

        public void PrintGetAddress()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  주소(OO시 OO대로/로/길) : ");
        }
        public void PrintIdDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  중복된 아이디입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintPhoneNumberDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  중복된 전화번호입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 도서 등록 화면 
        /// </summary>
        public void PrintGetBookId()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 번호 : ");
        }

        public void PrintBookIdDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  중복된 도서 번호입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void PrintGetBookTitle()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 제목: ");
        }

        public void PrintTitleDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  이미 있는 도서입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGetBookPublisher()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  출판사 : ");
        }

        public void PrintGetBookAuthor()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 저자 : ");
        }

        public void PrintGetBookPrice()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 가격 : ");
        }

        public void PrintBookPriceError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  너무 비싸지 않나요..? ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGetBookCount()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  등록 권수 : ");
        }

        public void PrintBookCountError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  너무 많지 않나요..? ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 프로그램 전반적으로 쓰는 화면 
        /// </summary>
        public void PrintInputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  다시 입력해주세요!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintInput()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "입력 : ");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
