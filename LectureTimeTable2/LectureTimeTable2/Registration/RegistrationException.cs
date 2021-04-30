using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LectureTimeTable2.Registeration
{
    class RegistrationException
    {
        private RegistrationScreen registrationScreen; 

        public RegistrationException()
        {
            this.registrationScreen = new RegistrationScreen();
        }

        public int HandleGetRegistrationMenu(string menuCheck)
        {
            int menu;
            
            Regex regex = new Regex(@"^[1-4]{1}$");
            
            while(!regex.IsMatch(menuCheck))
            {
                registrationScreen.PrintRegistrationMenu();
                registrationScreen.PrintMenuError();
                menuCheck = Console.ReadLine();
            }

            menu = Convert.ToInt32(menuCheck);
    
            return menu;
        }

        public string HandleGetReviseAttentionCourse(string attentionCourseNubmerCheck)
        {
            Regex regex = new Regex(@"^[q0-9]{1,2}$");

            while (!regex.IsMatch(attentionCourseNubmerCheck))
            {
                registrationScreen.PrintRegisterCourseNumberError();
                attentionCourseNubmerCheck = Console.ReadLine();
            }

            return attentionCourseNubmerCheck;
        }

        public string HandleRegisterCourseIndexByTitle(string courseIndexCheck)
        {
            Regex regex = new Regex(@"^[0-9]{1,3}$");

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
                    registrationScreen.PrintRegisterCourseNumberError();
                    courseIndexCheck = Console.ReadLine();
                }

                // 인덱스 범위를 초과할 때 
                while ((Convert.ToInt32(courseIndexCheck) < 1 || Convert.ToInt32(courseIndexCheck) > 169))
                {
                    registrationScreen.PrintRegisterCourseNumberError();
                    courseIndexCheck = Console.ReadLine();
                }
            }
            return courseIndexCheck;
        }

        public string HandleGetDeletCourse(string attentionCourseNubmerCheck)
        {
            Regex regex = new Regex(@"^[q0-9]{1,2}$");

            while (!regex.IsMatch(attentionCourseNubmerCheck))
            {
                registrationScreen.PrintDeletCourseNumberError();
                attentionCourseNubmerCheck = Console.ReadLine();
            }

            return attentionCourseNubmerCheck;
        }

        public string HandleRegisterCourseTitle(string courseTitleCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z가-힣]$");

            // 한글, 영어로만 이루어진 문자열이 아닐 때 반복문 실행
            while (regex.IsMatch(courseTitleCheck))
            {
                Console.Clear();
                registrationScreen.PrintTitleInputError();
                registrationScreen.PrintGetCourseTitle();
                courseTitleCheck = Console.ReadLine();
            }

            return courseTitleCheck;
        }
    }
}
