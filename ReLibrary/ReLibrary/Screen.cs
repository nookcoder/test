﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLibrary
{
    class Screen
    {
        // 메뉴 목록 출력
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

        // 회원가입 화면에 쓸 함수
        public void PrintSignUpName(string name)
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("                    이름     : {0}", name);
        }

        public void PrintSignUpPhoneNumber(string phoneNumber)
        {
            Console.WriteLine("\n");
            Console.Write("                    전화번호(-제외) : {0}", phoneNumber);
        }

        public void PrintSignUpAddress(string address)
        {
            Console.WriteLine("\n");
            Console.Write("                    주소 : {0}", address);
        }

        public void PrintSignUpId(string id)
        {
            Console.WriteLine("\n");
            Console.Write("                    아이디(8자리 이상) : {0}", id);
        }

        public void PrintLoginId(string id)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("                    아이디 : {0}", id);
        }

        public void PrintSignUpPassword()
        {
            Console.WriteLine("\n");
            Console.Write("                    비밀번호 : ");
        }

        public void PrintSignUpHint()
        {
            Console.WriteLine("\n");
            Console.Write("   출신 고등학교(아이디 찾기/탈퇴에 사용됩니다) : ");
        }

        public void PrintAskHint()
        {
            Console.WriteLine("\n");
            Console.Write("                    출신 고등학교 : ");
        }

        public void PrintNameError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ");
            Console.WriteLine("                    올바르지 않은 형식입니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                    이름     : ");
        }

        public void PrintPhoneNumberError(string name)
        {
            Console.Clear();
            PrintSignUpName(name);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    올바르지 않은 형식입니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                    전화번호(-제외) : ");

        }

        public void PrintIdError(string name,string phoneNumber,string address)
        {
            Console.Clear();
            PrintSignUpName(name);
            PrintSignUpPhoneNumber(phoneNumber);
            PrintSignUpAddress(address);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    올바르지 않은 형식입니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                    아이디(8자리 이상) : ");

        }


    }
}
