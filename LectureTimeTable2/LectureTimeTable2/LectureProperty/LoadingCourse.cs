using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using LectureTimeTable2.VOs;

namespace LectureTimeTable2.LectureProperty
{
    class LoadingCourse
    {
        private CourseScreen courseScreen;
        private List<CourseVO> course;
        private int index; 

        public LoadingCourse(List<CourseVO> courses)
        {
            this.courseScreen = new CourseScreen();
            this.course = courses;

            this.index = 0;
        }

        // 컴퓨터 전공 강의 출력
        public void LoadComputeMajor()
        {
            courseScreen.PrintCourseLabel();
            Console.WriteLine("\n");
            for (index = 0; index < 103; index++)
            {
                Console.Write(index < 10 ? $"00{index}" : index < 100 ? $"0{index}" : $"{index}");
                ShowCourse(index);
            }
            courseScreen.PrintProgressNotice();
            Console.ReadLine();
            Console.SetWindowSize(100, 40);         
        }

        // 지능기전 전공 강의 출력 
        public void LoadIntelligenceMajor()
        {
            try
            {
                Console.SetWindowSize(160, 40);

                courseScreen.PrintCourseLabel();
                Console.WriteLine("\n");
                for (index = 0; index <= 48; index++)
                {
                    Console.Write(index < 10 ? $"00{index}" : index < 100 ? $"0{index}" : $"{index}");
                    ShowCourse(index);
                }
                courseScreen.PrintProgressNotice();
                Console.ReadLine();
                Console.SetWindowSize(100, 40);
                Console.SetWindowSize(100, 40);
            }

            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 기계항공 전공 강의 출력 
        public void LoadEngineeringMajor()
        {
            try
            {
                Console.SetWindowSize(160, 40);

                courseScreen.PrintCourseLabel();
                Console.WriteLine("\n");
                for (index = 0; index <= 18; index++)
                {
                    Console.Write(index < 10 ? $"00{index}" : index < 100 ? $"0{index}" : $"{index}");
                    ShowCourse(index);
                }
                courseScreen.PrintProgressNotice();
                Console.ReadLine();

                Console.SetWindowSize(100, 40);
            }

            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // 학수 번호로 강의 출력 -> 종료 기능 다시 만들기 
        public void LoadCourseByCourseNumber(string courseNumber, string distribution)
        {
            bool isFound = Constants.NONE;
            int courseIndex = 1;

            // 분반을 입력받지 않았을 때
            if (distribution == "n")
            {
                if (courseNumber == "q")
                {

                }

                else
                {
                    index = 0;

                    // 입력된 학수 번호와 일치하는 강좌 출력
                    while(index < 169)
                    {
                        if (courseNumber == course[index].CourseNumber)
                        {
                            isFound = Constants.FIND;
                            Console.Write(courseIndex < 10 ? $"00{courseIndex}" : index < 100 ? $"0{courseIndex}" : $"{courseIndex}");
                            ShowCourse(index);
                            courseIndex++;
                        }

                        index++;
                    }
                
                    // 입력된 학수 번호와 일치하는 강좌가 없을 때
                    if(isFound)
                    {
                        Console.Clear();
                        courseScreen.PrintNoFoundLecture();
                    }

                }

                courseScreen.PrintProgressNotice();
                Console.ReadKey();
            }

            // 분반을 입력받았을때
            else
            {
                index = 0;

                while(index < 169)
                {
                    if(courseNumber == course[index].CourseNumber && distribution == course[index].Distribution)
                    {
                        isFound = Constants.FIND;
                        Console.Write(courseIndex);
                        ShowCourse(index);
                        courseIndex++;
                    }

                    index++;
                }

                // 입력된 학수 번호와 일치하는 강좌가 없을 때
                if (isFound)
                {
                    Console.Clear();
                    courseScreen.PrintNoFoundLecture();
                }

                courseScreen.PrintProgressNotice();
                Console.ReadKey();
            }
        }

        public void LoadCourseByProfessorName(string professor)
        {
            bool isFound = Constants.NONE;
            index = 0;
            int courseIndex = 1;

            while(index < 169 )
            {
                if(course[index].Professor.Contains(professor))
                {
                    isFound = Constants.FIND;
                    Console.Write(courseIndex < 10 ? $"00{courseIndex}" : index < 100 ? $"0{courseIndex}" : $"{courseIndex}");
                    ShowCourse(index);
                    courseIndex++;
                }

                index++;
            }

            if (isFound)
            {
                Console.Clear();
                courseScreen.PrintNoFoundLecture();
            }

            courseScreen.PrintProgressNotice();
            Console.ReadKey();
        }

        // 강의 시간표 한줄 출력
        public void ShowCourse(int index)
        {
            Console.SetWindowSize(160, 40);
            Console.Write(" " + course[index].Major.PadRight(20 - course[index].Major.Length) + " ");
            Console.Write(course[index].CourseNumber.PadRight(2, ' ') + " ");
            Console.Write(course[index].Distribution + " ");
            Console.Write(course[index].Title + " ");
            Console.Write(course[index].Sortation + " ");
            Console.Write(course[index].Grade + " ");
            Console.Write(course[index].Score + " ");
            Console.Write(course[index].CourseTime + " ");
            Console.Write(course[index].ClassRoom + " ");
            Console.Write(course[index].Professor + " ");
            Console.Write(course[index].Language + " ");
            Console.WriteLine("\n");
        }
    }
}
