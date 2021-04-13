using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class MemberLogin
    {
        public MemberLogin()
        {
            SetMemberMenu();
        }

        List<Member> members = new List<Member>();
        public string memberName;
        public string phoneNumber;
        public string memberId;
        public string password;
        public int index;

        // MemberLogin Class 호출 시 실행 함수.
        public void SetMemberMenu()
        {
            string menu;
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
                    SignUpMember();
                }

                else if (_menu == "2")
                {
                    isError = NoError(isError);
                    BookManagement bookManagement = new BookManagement();
                    bookManagement.SetMemberBookMenu();

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



        public void SignUpMember()
        {
            Console.Clear();
            GetMemberInfo();
            Console.Clear();
            SetMemberMenu();
        }

        public void GetMemberInfo()
        {
            
            Console.WriteLine("");
            Console.WriteLine("");
            PrintGetMemberInfo("이름");
            memberName = Console.ReadLine();
            PrintGetMemberInfo("전화번호");
            phoneNumber = Console.ReadLine();
            PrintGetMemberInfo("아이디");
            memberId = Console.ReadLine();
            PrintGetMemberInfo("비밀 번호");
            password = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("           회원가입이 완료됐습니다.");
            Console.ReadKey();
            members.Add(new Member(memberName, phoneNumber, memberId, password));
        }

        /*public string HandlePhoneNumber()
        {
            string _phoneNumber;
             

            PrintSaveMemberInfo("이름", memberName);
            PrintGetMemberInfo("전화 번호(-제외)");
            _phoneNumber = Console.ReadLine();

            if(_phoneNumber.Length != 11)
            {
                bool isError = true;

                while(isError)
                {
                    _phoneNumber = PrintPhoneNumberError();
                    isError = CheckError(_phoneNumber);
                }
            }

            else
            {
                bool isError = true;

                while (isError)
                {
                    _phoneNumber = PrintPhoneNumberError();
                    isError = CheckError(_phoneNumber);
                }
            }

            return _phoneNumber;
            
        }*/

        /*public bool CheckError(string _phoneNumber)
        {
            bool _isError = true;
            int count = 0;
            for (int Index = 0; Index < _phoneNumber.Length; Index++)
            {
                if (_phoneNumber[Index] - '0' >= 0 && _phoneNumber[Index] - '0' <= 9)
                {
                    count++;
                }
            }
            
            if(count == 11)
            {
                _isError = false;
            }

            return _isError;
        }*/

        /*public string PrintPhoneNumberError()
        {
            string _phoneNumber;
            PrintSaveMemberInfo("이름", memberName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("              다시 입력해주세요!!!");
            Console.ForegroundColor = ConsoleColor.White;
            PrintGetMemberInfo("전화 번호(-제외)");
            _phoneNumber = Console.ReadLine();

            return _phoneNumber;
        }*/

        //public void HandleMemberId()
     

        //public void HandlePassword()

        public void PrintGetMemberInfo(string text)
        {
            Console.Write($"              {text} : ");
        }

        public void PrintSaveMemberInfo(string text, string _info)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write($"              {text} : {_info}\n");
        }
    }
}
