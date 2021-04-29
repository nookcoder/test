using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.LectureProperty
{
    class CourseScreen
    {
        public void PrintCourseLabel()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("No  개설학과전공         학수번호 분반 교과목명                           이수구분 학년 학점 요일 및 강의시간        강의실        메인교수명  언어");
            Console.Write("====================================================================================================================================================");
            Console.WriteLine("\n");
        }
        public void PrintCourseTimeTableMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[1] 학과 전공 검색");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[2] 학수 번호 검색");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[3] 교과목명 검색");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[4] 학년 검색");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[5] 교수명 검색");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[6] 전체 출력");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[7] 뒤로 가기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

        // 전공 종류 출력
        public void PrintMajorSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[1] 컴퓨터공학과");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[2] 지능기전공학부");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[3] 기계항공우주공학부");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("[4] 뒤로 가기");
            Console.WriteLine("\n"); Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

        // 종료키 안내
        public void PrintExitNotice()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("종료는 q를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 학수번호 검색 출력
        public void PrintGetCourseNumber(string courseNumber)
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("학수 번호 : {0}", courseNumber);
        }

        // 분반 입력 출력 
        public void PrintGetDistribution()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("분반을 모르면 n를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("분반 : ");
        }

        // 과목명 입력 출력
        public void PrintGetSubjectName()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("과목 명 : ");
        }

        // 학년 입력 출력 
        public void PrintGetGrade()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("학년 : ");
        }

        // 교수명 입력 출력 
        public void PrintGetProfessor()
        {
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("교수 명 : ");
        }

        // 메뉴 입력 받는 출력문
        public void PrintMenuInput()
        { 
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,41}", " "));
            Console.Write("입력 : ");
        }

        // 예외 문자열 입력 시 출력문
        public void PrintMenuError()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("잘못 입력하셨습니다.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // 학년 예외 문자열 입력 시 출력문
        public void PrintGradeError()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("1~4 만 입력해주세요.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintProfessorNameError()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("{0,41}", " "));
            Console.WriteLine("2글자 이상 한글,영어를 입력해주세요");
            Console.ForegroundColor = ConsoleColor.White;
        }


        // 강의 시간표 조회가 끝나면 나올 출력문 
        public void PrintProgressNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "계속 진행하시려면 아무키나 눌러주세요."));
        }

        // 강의가 없을 때 출력함수
        public void PrintNoFoundLecture()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "해당 강좌는 존재하지 않습니다."));
        }
    }
}
