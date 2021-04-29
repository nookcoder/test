
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace LectureTimeTable2.AttentionProperty
{
    class AttentionException
    {
        private AttentionScreen AttentionScreen;

        public AttentionException()
        {
            this.AttentionScreen = new AttentionScreen();
        }
        
        public int HandleAttentionMenuInupt(string menuCheck)
        {
            Regex regex = new Regex(@"^[1-3]$");
            
            // 입력된 문자열이 1,2,3이 아니면 반복문 실행
            while(!regex.IsMatch(menuCheck))
            {
                AttentionScreen.PrintAttentionSearchMenu();
                AttentionScreen.PrintMenuError();
                AttentionScreen.PrintMenuInput();
                menuCheck = Console.ReadLine();
            }

            return Convert.ToInt32(menuCheck);
        }

        public string HandleAttentionCourseTitle(string courseTitleCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z가-힣]$");
            
            // 한글, 영어로만 이루어진 문자열이 아닐 때 반복문 실행
            while(regex.IsMatch(courseTitleCheck))
            {
                Console.Clear();
                AttentionScreen.PrintMenuError();
                AttentionScreen.PrintGetCourseTitle();
                courseTitleCheck = Console.ReadLine();
            }

            return courseTitleCheck; 
        }

        public string HandleAttentionCourseIndex(string courseIndexCheck)
        {
            Regex regex = new Regex(@"^[1-9]{1,3}$");

            // 종료(q)를 입력받았을 때
            if (courseIndexCheck == "q")
            {
                return "q";
            }
            
            // 숫자가 아닐 때 반복문 실행
            else
            {
                while (!regex.IsMatch(courseIndexCheck))
                {
                    AttentionScreen.PrintGetAttentionCourseNumberError();
                    courseIndexCheck = Console.ReadLine();
                }

                // 인덱스 범위를 초과할 때 
                while ((Convert.ToInt32(courseIndexCheck) < 1 || Convert.ToInt32(courseIndexCheck) > 169))
                {
                    AttentionScreen.PrintGetAttentionCourseNumberError();
                    courseIndexCheck = Console.ReadLine();
                }
            }
            return courseIndexCheck;
        }

        public string HandleGetReviseAttentionCourse(string attentionCourseNubmerCheck)
        {
            Regex regex = new Regex(@"^[q1-9]{1,2}$");

            while(!regex.IsMatch(attentionCourseNubmerCheck))
            {
                AttentionScreen.PrintGetReviseAttentionCourseError();
                attentionCourseNubmerCheck = Console.ReadLine();
            }
            
            return attentionCourseNubmerCheck;
        }
    }
}
