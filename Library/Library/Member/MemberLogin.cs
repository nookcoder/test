using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class MemberLogin
    {
        public MemberLogin()
        {
            Console.SetWindowSize(50, 30);
            SetMemberMenu();
        }

        List<Member> members = new List<Member>();
        
        // MemberLogin Class 호출 시 실행 함수.
        public void SetMemberMenu()
        {
            string  menu; 
            Console.Clear();
            PrintMemberMenu();
            Console.Write("                메뉴 입력:");
            menu = Console.ReadLine();
            HandleExceptMemberMenu(menu);
        }

        // MemberLogin 출력 화면.
        public void PrintMemberMenu()
        {
            Console.WriteLine("    ==================================");
            Console.WriteLine(" ");
            Console.WriteLine("              [1] 회원 가입           ");
            Console.WriteLine("");
            Console.WriteLine("              [2]  로그인             ");
            Console.WriteLine("");
            Console.WriteLine("              [3] 회원 탈퇴           ");
            Console.WriteLine("");
            Console.WriteLine("              [4] 뒤로 가기           ");
            Console.WriteLine("");
            Console.WriteLine("    ==================================");
        }

        // 입력된 메뉴 처리.
        public void HandleExceptMemberMenu(string _menu)
        {
            bool isError = true;

            while (isError)
            {
                if (_menu == "1")
                {
                    isError = NoError(isError);

                }

                else if (_menu == "2")
                {
                    isError = NoError(isError);


                }

                else if (_menu == "3")
                {
                    isError = NoError(isError);

                }

                else if (_menu == "4")
                {
                    isError = NoError(isError);
                    Main main = new Main();
                }

                else
                {
                    Console.Clear();
                    PrintMemberMenu();
                    Console.WriteLine("           잘못 입력하셨습니다.");
                    Console.WriteLine("    ==================================");
                    Console.Write("                메뉴 입력:");
                    _menu = Console.ReadLine();
                }
            }
        }

        // 입력된 메뉴에 문제가 없을 때. 
        public bool NoError(bool _isError)
        {
            _isError = false;
            Console.Clear();

            return _isError;
        }
    }
}
