using System;

namespace Library
{
    class Main
    {
        public Main()
        {
            Console.SetWindowSize(45, 30);
            SetFirstMenu();
        }

        // Main 클래스 생성할 때 호출될 함수. 
        public void SetFirstMenu()
        {
            string firstMenu;

            PrintFirstPage(); 
            Console.Write("                메뉴 입력:");
            firstMenu = Console.ReadLine();
            HandleExceptFirstMenu(firstMenu);

        }

        // 도서관 실행 시 나타날 화면 출력
        public void PrintFirstPage()
        {
            Console.WriteLine("    ==================================");
            Console.WriteLine("");
            Console.WriteLine("             [1] 회원 로그인");
            Console.WriteLine("");
            Console.WriteLine("             [2] 관리자 로그인    ");
            Console.WriteLine("");
            Console.WriteLine("    ==================================");
        }

        // 메뉴 입력 예외 처리
        public void HandleExceptFirstMenu(string _firstMenu)
        {
            bool isError = true;
            
            while (isError)
            {
                if (_firstMenu == "1")
                {
                    isError = false;
                    MemberLogin memberLogin = new MemberLogin();
                }

                else if (_firstMenu == "2")
                {
                    isError = false; 
                    ManagerLogin managerLogin = new ManagerLogin(); 
                }

                else
                {
                    Console.Clear();
                    PrintFirstPage();
                    Console.WriteLine("           잘못 입력하셨습니다.");
                    Console.WriteLine("    ==================================");
                    Console.Write("                메뉴 입력:");
                    _firstMenu = Console.ReadLine();
                }
            }
        }
    }
}
