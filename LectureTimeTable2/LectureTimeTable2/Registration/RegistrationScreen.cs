using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.Registeration
{
    class RegistrationScreen
    {
        public void PrintCourseLabel()
        {
            Console.WriteLine("\n");
            Console.WriteLine("No  개설학과전공         학수번호 분반 교과목명                           이수구분 학년 학점 요일 및 강의시간        강의실        메인교수명  언어");
            Console.Write("====================================================================================================================================================");
            Console.WriteLine("\n");
        }


        public void PrintRegistrationMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[1] 관심과목 조회/신청");
            Console.WriteLine("\n");    
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[2] 강의 검색/신청");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[3] 수강 신청 내역 조회/삭제");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[4] 뒤로 가기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

        public void PrintMenuInput()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("입력 : ");
        }

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

        public void PrintGetRegisterCourseNumber()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("===================종료는 q를 입력해주세요===================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("수강 신청 번호(왼쪽 첫번째줄)를 입력해주세요 ");
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("앞자리 0은 제외해주세요(ex 001 -> 1)");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        public void PrintRegisterCourseNumberError()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("===================종료는 q를 입력해주세요===================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("담을 과목 번호(왼쪽 첫번째줄)를 입력해주세요 ");
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("앞자리 0은 제외해주세요(ex 001 -> 1)");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("1~169 사이의 숫자만 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String.Format("{0,30}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        // 과목명 입력 출력
        public void PrintGetCourseTitle()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.WriteLine("======================전체 출력 : 엔터=======================");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("과목 명 : ");
        }

        public void PrintProgressNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "계속 진행하시려면 아무키나 눌러주세요."));
        }

        public void PrintAddNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "수강신청이 완료되었습니다."));
        }

        public void PrintTimeOverlap()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,50}", "시간이 겹치는 강의가 있습니다"));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintNoFoundLecture()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "해당 강좌는 존재하지 않습니다."));
        }

        public void PrintTooMuchCredit()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("수강가능 학점을 초과했습니다!!!!!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintOverlapCourse()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("이미 담은 과목입니다!!!!!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintRegisterListLabel()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,64}", " "));
            Console.WriteLine("수강 신청 과목");
        }

        public void PrintCreditLabel()
        {
            Console.Write(String.Format("{0,64}", " "));
            Console.Write("신청 학점 : ");
        }

        public void PrintNoRegistration()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,35}", " "));
            Console.Write("수강 신청한 과목이 없습니다.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 삭제할 과목 인덱스 입력 받기 출력
        public void PrintGetReviseRegistrationCourse()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,40}", " "));
            Console.Write("===================종료는 q를 입력해주세요===================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,50}", " "));
            Console.WriteLine("삭제할 과목 번호(왼쪽 첫번째줄)를 입력해주세요 ");
            Console.Write(String.Format("{0,50}", " "));
            Console.WriteLine("앞자리 0은 제외해주세요(ex 001 -> 1)");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,51}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        public void PrintDeletCourseNumberError()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("===================종료는 q를 입력해주세요===================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("삭제할 과목 번호(왼쪽 첫번째줄)를 입력해주세요 ");
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("앞자리 0은 제외해주세요(ex 001 -> 1)");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("1~169 사이의 숫자만 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String.Format("{0,30}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        public void PrintDeletNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "관심과목 삭제가 완료되었습니다."));
        }

        public void PrintTitleInputError()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("잘못 입력하셨습니다.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 강의가 없을 때 출력함수
        public void PrintNoFoundCourse()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "해당 강좌는 존재하지 않습니다."));
        }

    }
}

