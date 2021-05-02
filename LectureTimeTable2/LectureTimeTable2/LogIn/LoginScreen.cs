using System;

namespace LectureTimeTable2.Login
{
    class LoginScreen
    {
        public void PrintLTT()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,50}", "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■"));
            Console.WriteLine(String.Format("{0,82}", "■                                                                ■"));
            Console.WriteLine(String.Format("{0,68}", "■   ■■                 □□□□□□             ■■■■■■   ■"));
            Console.WriteLine(String.Format("{0,68}", "■   ■■                 □□□□□□             ■■■■■■   ■"));
            Console.WriteLine(String.Format("{0,76}", "■   ■■                     □□                     ■■       ■"));
            Console.WriteLine(String.Format("{0,76}", "■   ■■                     □□                     ■■       ■"));
            Console.WriteLine(String.Format("{0,76}", "■   ■■                     □□                     ■■       ■"));
            Console.WriteLine(String.Format("{0,73}", "■   ■■■■■               □□                     ■■       ■"));
            Console.WriteLine(String.Format("{0,73}", "■   ■■■■■               □□                     ■■       ■"));
            Console.WriteLine(String.Format("{0,82}", "■                                                                ■"));
            Console.WriteLine(String.Format("{0,50}", "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■"));
            Console.WriteLine(String.Format("{0,52}", "■■■■■■■■■종료하시려면 q를 입력해주세요 ■■■■■■■■■■"));
            Console.WriteLine(String.Format("{0,50}", "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 학번 입력 받기
        public void PrintId(string id)
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,39}", " "));
            Console.Write($"학번 : {id}");
        }

        // 비밀번호 입력 받기
        public void PrintPassword(string password)
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,39}", " "));
            Console.Write($"비밀번호 : {password}");
        }

        // 학번 입력 오류시 
        public void PrintReWriteId()
        {
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,46}", "다시입력해주세요"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,39}", " "));
            Console.Write($"학번 : ");
        }

        // 비밀번호 입력 오류 시
        public void PrintReWritePassword()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,53}", "8자리이상 12자리 이하 숫자/영어조합만 입력해주세요"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,39}", " "));
            Console.Write($"비밀번호 : ");
        }

        // 로그인 실패 
        public void PrintNoExistId()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,50}","가입하지 않은 아이디이거나,잘못된 비밀번호입니다."));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}","계속 진행하시려면 아무키나 눌러주세요."));
        }

        // 로그인 후 띄울 메뉴창 
        public void PrintInitialMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[1] 강의 시간표");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[2] 관심 과목 담기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[3] 수강 조회/신청");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[4] 시간표 조회");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[5] 종료 하기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

        // 메뉴 입력 받기 
        public void PrintInitialMenuInput()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("입력 : ");
        }

        // 메뉴 입력 오류 시 
        public void PrintMenuError()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("잘못 입력하셨습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("입력 : ");
        }

        public void PrintGetPrintOrSvae()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[1] 콘솔에서 출력하기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[2] 바탕화면에 저장하기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[3] 뒤로 가기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

        public void PrintProgressNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "계속 진행하시려면 아무키나 눌러주세요."));
        }

    }
}
