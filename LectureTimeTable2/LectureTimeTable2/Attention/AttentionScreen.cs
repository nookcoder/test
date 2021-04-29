using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.AttentionProperty
{
    class AttentionScreen
    {
        public void PrintCourseLabel()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("No  개설학과전공         학수번호 분반 교과목명                           이수구분 학년 학점 요일 및 강의시간        강의실        메인교수명  언어");
            Console.Write("====================================================================================================================================================");
            Console.WriteLine("\n");
        }

        // 관심과목담기 검색 메뉴 출력
        public void PrintAttentionSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[1] 과목 검색 및 추가");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[2] 관심 과목 조회/수정");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[3] 뒤로 가기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

        public void PrintMenuInput()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("입력 : ");
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

        // 관심 과목 인덱스 입력 받기 출력
        public void PrintGetAttentionCourseNumber()
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
            Console.Write(String.Format("{0,41}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        // 관심 과목 인덱스 입력 받기 오류 시 출력
        public void PrintGetAttentionCourseNumberError()
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


        // 강의가 없을 때 출력함수
        public void PrintNoFoundLecture()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "해당 강좌는 존재하지 않습니다."));
        }

        // 학점을 초과했을 때
        public void PrintTooMuchCredit()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("수강가능 학점을 초과했습니다!!!!!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 이미 담은 과목일 때 
        public void PrintOverlapCourse()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,30}", " "));
            Console.WriteLine("이미 담은 과목입니다!!!!!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 관심 과목 인덱스 입력 받기 출력
        public void PrintGetReviseAttentionCourse()
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
            Console.Write(String.Format("{0,41}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        // 관심 과목 인덱스 입력 받기 출력
        public void PrintGetReviseAttentionCourseError()
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
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("잘못 입력하셨습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String.Format("{0,41}", " "));
            Console.Write($"과목 번호(왼쪽 첫번째줄) : ");
        }

        // 강의 시간표 조회가 끝나면 나올 출력문 
        public void PrintProgressNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "계속 진행하시려면 아무키나 눌러주세요."));
        }

        public void PrintAddNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "관심과목 등록이 완료되었습니다."));
        }

        public void PrintDeletNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "관심과목 삭제가 완료되었습니다."));
        }

        // 메뉴 입력 오류
        public void PrintMenuError()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("잘못 입력하셨습니다.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
