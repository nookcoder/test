using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LectureTimeTable2.VOs;

namespace LectureTimeTable2.LectureProperty
{
    class CourseException
    {
        CourseScreen courseScreen;
        private List<StudentsVO> students;
        private List<CourseVO> courses;
        private List<StudentCourseVO> studentCourses;
        public CourseException()
        {
            this.courseScreen = new CourseScreen();
        }

        // 강의 검색 방법 선택 메뉴창에서 예외처리 
        public string HandleLectureTimeTableMenuInput(string menuCheck)
        {
            while (Constants.ERROR)
            {
                if (Regex.IsMatch(menuCheck, @"^[1-6]$"))
                {
                    break;
                }

                courseScreen.PrintCourseTimeTableMenu();
                courseScreen.PrintMenuError();
                courseScreen.PrintMenuInput();
                menuCheck = Console.ReadLine();
            }

            return menuCheck;
        }

        // 전공으로 검색에서 나오는 메뉴 예외처리 
        public string HandleSearchByMajor(string menuCheck)
        {
            while (Constants.ERROR)
            {
                if (Regex.IsMatch(menuCheck, @"^[1-4]$"))
                {
                    break;
                }

                courseScreen.PrintMajorSearchMenu();
                courseScreen.PrintMenuError();
                courseScreen.PrintMenuInput();
                menuCheck = Console.ReadLine();
            }

            return menuCheck;
        }

        public string HnadleGetCourseNumber(string courseNumberCheck)
        {
            Regex regex = new Regex(@"^[0-9]{6}$");

            while (Constants.ERROR)
            {
                if (regex.IsMatch(courseNumberCheck))
                {
                    courseScreen.PrintExitNotice();
                    courseScreen.PrintGetCourseNumber(courseNumberCheck);
                    break;
                }

                //종료 기능
                else if (courseNumberCheck == "q")
                {
                    courseNumberCheck = "q";
                    break;
                }

                else
                {
                    courseScreen.PrintExitNotice();
                    courseScreen.PrintMenuError();
                    courseScreen.PrintGetCourseNumber(null);
                    courseNumberCheck = Console.ReadLine();
                }
            }

            return courseNumberCheck;
        }

        public string HnadleGetDistribution(string distributionCheck, string courseNumber)
        {
            Regex regex = new Regex(@"^[0-9n]{1,3}$");

            while (Constants.ERROR)
            {
                // 숫자만 입력받았을 때 
                if (regex.IsMatch(distributionCheck))
                {
                    break;
                }

                // 종료기능
                else if (distributionCheck == "q")
                {

                    break;
                }

                // 잘못입력받았을 때 
                else
                {
                    courseScreen.PrintExitNotice();
                    courseScreen.PrintGetCourseNumber(courseNumber);
                    courseScreen.PrintMenuError();
                    courseScreen.PrintGetDistribution();
                    distributionCheck = Console.ReadLine();
                }
            }

            return distributionCheck;
        }

        public string HandleGetProfessorName(string professorCheck)
        {
            Regex regex = new Regex(@"^[a-zA-Z가-힣]{2,}$");

            while(Constants.ERROR)
            {
                if(regex.IsMatch(professorCheck))
                {
                    break;
                }

                else
                {
                    Console.Clear();
                    courseScreen.PrintProfessorNameError();
                    courseScreen.PrintGetProfessor();
                    professorCheck = Console.ReadLine();
                }
            }

            return professorCheck;
        }
    }
}
