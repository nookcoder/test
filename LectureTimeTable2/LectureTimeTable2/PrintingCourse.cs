using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LectureTimeTable2
{
    class PrintingCourse
    {
        public void PrintCourse(string major,string courseNumber, string distribution, string courseName, string sortation, string grade, string credit, string courseTime, string classRoom, string professor, string language)
        {
            int noHangleCountOfCourseName = FindNoHangle(courseName);
            int padNumberOfCourseTime = GetPadRightNumberOfCourseTIme(courseTime);
            int hangleCountOfCourseTime = FindHangle(courseTime);
            int padNumberOfClassRoom = GetPadRightNumberOfClassRoom(classRoom);
            int hangleCountOfProfessor = FindHangle(professor);

            Console.SetWindowSize(180, 40);
            Console.Write(major.PadRight(20 - major.Length, ' '));
            Console.Write(courseNumber.PadRight(8, ' '));
            Console.Write(distribution.PadRight(4, ' '));
            Console.Write(courseName.PadRight(22 - courseName.Length + noHangleCountOfCourseName), ' ');
            Console.Write(sortation.PadRight(7, ' '));
            Console.Write(grade.PadRight(3, ' '));
            Console.Write(credit.PadRight(5, ' '));
            Console.Write(courseTime.PadRight(padNumberOfCourseTime - courseTime.Length + hangleCountOfCourseTime), ' ');
            Console.Write(classRoom.PadRight(padNumberOfClassRoom - classRoom.Length), ' ');
            Console.Write(professor.PadRight(22 - hangleCountOfProfessor), ' ');
            Console.Write(language);    
            Console.Write("\n");
        }

        // 문자열에서 한글이 아닌 문자 개수 찾기 
        public int FindNoHangle(string str)
        {
            int noHangleCount;
            string noHangle;
            noHangle = Regex.Replace(str,@"[가-힣]", "");
            noHangleCount = noHangle.Length;
            return noHangleCount;
        }

        // 문자열에서 한글 개수 찾기 
        public int FindHangle(string str)
        {
            int hangleCount;
            string hangle;
            hangle = Regex.Replace(str, @"[^가-힣]", "");
            hangleCount = hangle.Length;
            return hangleCount; 
        }

        // 강의 시간 PadRight 값 결정 
        public int GetPadRightNumberOfCourseTIme(string courseTime)
        {
            if(courseTime.Length >28)
            {
                return 59;
            }

            else
            {
                return 46; 
            }
        }


        // 강의실 PadRight 값 결정 
        public int GetPadRightNumberOfClassRoom(string classRoom)
        {
            if(classRoom.Length == 5)
            {
                return 18; 
            }

            else if(classRoom.Length == 4)
            {
                return 17;
            }

            else if(classRoom.Length == 0 )
            {
                return 14 + classRoom.Length;
            }
            else
            {
                return 23; 
            }
        }
    }
}
