using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.LectureProperty
{
    class LectureScreen
    {
        public void PrintLectureTimeTableMenu()
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
            Console.WriteLine("[6] 뒤로 가기");
            Console.WriteLine("\n");
            Console.Write(String.Format("{0,20}", " "));
            Console.Write("============================================================");
        }

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
        
        public void PrintMenuInput()
        { 
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

        public void PrintProgressNotice()
        {
            Console.WriteLine("\n");
            Console.WriteLine(String.Format("{0,50}", "계속 진행하시려면 아무키나 눌러주세요."));
        }
    }
}
