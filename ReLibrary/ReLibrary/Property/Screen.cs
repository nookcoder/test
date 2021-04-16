using System;

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

        public void PrintManagerMenu()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("                    [1] 회원 등록                           ");
            Console.WriteLine("                    [2] 회원 삭제                           ");
            Console.WriteLine("                    [3] 회원 검색                      ");
            Console.WriteLine("                    [4] 도서 등록                           ");
            Console.WriteLine("                    [5] 도서 삭제                           ");
            Console.WriteLine("                    [6] 전체 도서 출력                      ");
            Console.WriteLine("                    [7] 도서 검색                           ");
            Console.WriteLine("                    [8] 뒤로 가기                           ");
            Console.WriteLine("============================================================");
        }

        public void PrintSearchingUserMenu()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("                    [1] 이름 검색                           ");
            Console.WriteLine("                    [2] 아이디 검색                          ");
            Console.WriteLine("                    [3] 뒤로 가기                            ");
            Console.WriteLine("============================================================");
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

        public void PrintIdError(string name, string phoneNumber, string address)
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

        // 도서관련 화면
        public void PrintBookNumber(string number)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("                    번호     : {0}", number);
        }
        public void PrintBookNumberError(string number)
        {
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    숫자만 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                    번호     : {0}", number);
        }


        public void PrintBookTitle(string title)
        {
            Console.WriteLine("\n ");
            Console.Write("                    제목     : {0}", title);
        }

        public void PrintBookAuthor(string author)
        {
            Console.WriteLine("\n ");
            Console.Write("                    작가 이름     : {0}", author);
        }

        public void PrintBookPublisher(string publisher)
        {
            Console.WriteLine("\n ");
            Console.Write("                    출판사     : {0}", publisher);
        }

        public void PrintBookForDelet()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("         삭제하실 도서 번호 혹은 도서 제목을 입력해주세요");
            Console.Write("                                   : ");
        }

        public void PrintBookSearch()
        {
            Console.WriteLine("\n");
            Console.Write("찾으시는 도서 제목 혹은 저자를 입력해주세요 : ");
        }
    }
}
