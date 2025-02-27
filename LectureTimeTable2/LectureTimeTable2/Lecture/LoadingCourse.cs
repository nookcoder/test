﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using LectureTimeTable2.VOs;
using System.Text.RegularExpressions;

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
                Console.Write(index < 10 ? $"00{index} " : index < 100 ? $"0{index} " : $"{index} ");
                ShowCourse(index);
            }
            courseScreen.PrintProgressNotice();
            Console.ReadLine();
            Console.SetWindowSize(100, 40);
        }

        // 지능기전 전공 강의 출력 
        public void LoadIntelligenceMajor()
        {

            Console.SetWindowSize(160, 40);

            courseScreen.PrintCourseLabel();
            Console.WriteLine("\n");
            for (index = 0; index <= 48; index++)
            {
                Console.Write(index < 10 ? $"00{index} " : index < 100 ? $"0{index} " : $"{index} ");
                ShowCourse(index);
            }
            courseScreen.PrintProgressNotice();
            Console.ReadLine();
            Console.SetWindowSize(100, 40);
            Console.SetWindowSize(100, 40);

        }

        // 기계항공 전공 강의 출력 
        public void LoadEngineeringMajor()
        {

            Console.SetWindowSize(160, 40);

            courseScreen.PrintCourseLabel();
            Console.WriteLine("\n");
            for (index = 0; index <= 18; index++)
            {
                Console.Write(index < 10 ? $"00{index} " : index < 100 ? $"0{index} " : $"{index} ");
                ShowCourse(index);
            }
            courseScreen.PrintProgressNotice();
            Console.ReadLine();

            Console.SetWindowSize(100, 40);
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

                    courseScreen.PrintCourseLabel();
                    // 입력된 학수 번호와 일치하는 강좌 출력
                    while (index < 169)
                    {
                        if (courseNumber == course[index].CourseNumber)
                        {
                            isFound = Constants.FIND;
                            Console.Write(courseIndex < 10 ? $"00{courseIndex} " : index < 100 ? $"0{courseIndex} " : $"{courseIndex} ");
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

                }

                courseScreen.PrintProgressNotice();
                Console.ReadKey();
            }

            // 분반을 입력받았을때
            else
            {
                index = 0;

                while (index < 169)
                {
                    if (courseNumber == course[index].CourseNumber && distribution == course[index].Distribution)
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

        // 교과목 명으로 강의 출력 
        public void LoadCourseBySubjectName(string subjectName)
        {
            bool isFound = Constants.NONE;
            int index = 0;
            int courseIndex = 1;

            courseScreen.PrintCourseLabel();
            while (index < 169)
            {
                if (course[index].Title.Contains(subjectName))
                {
                    isFound = Constants.FIND;
                    Console.Write(courseIndex < 10 ? $"00{courseIndex} " : index < 99 ? $"0{courseIndex} " : $"{courseIndex} ");
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

        // 학년으로 강의 출력
        public void LoadCourseByGrade(string grade)
        {
            bool isFound = Constants.NONE;
            index = 0;
            int courseIndex = 1;

            courseScreen.PrintCourseLabel();
            while (index < 169)
            {
                if (course[index].Grade.Contains(grade))
                {
                    isFound = Constants.FIND;
                    Console.Write(courseIndex < 10 ? $"00{courseIndex} " : index < 100 ? $"0{courseIndex} " : $"{courseIndex} ");
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


        // 교수명으로 강의 출력 
        public void LoadCourseByProfessorName(string professor)
        {
            bool isFound = Constants.NONE;
            index = 0;
            int courseIndex = 1;

            courseScreen.PrintCourseLabel();
            while (index < 169)
            {
                if (course[index].Professor.Contains(professor))
                {
                    isFound = Constants.FIND;
                    Console.Write(courseIndex < 10 ? $"00{courseIndex} " : index < 100 ? $"0{courseIndex} " : $"{courseIndex} ");
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

        public void LoadAllCourse()
        {
            int courseIndex = 1;
            int index;
            courseScreen.PrintCourseLabel();
            index = 0;
            while (index < 169)
            {
                Console.Write(courseIndex < 10 ? $"00{courseIndex} " : index < 99 ? $"0{courseIndex} " : $"{courseIndex} ");
                ShowCourse(index);
                courseIndex++;
                index++;
            }
            courseScreen.PrintProgressNotice();
            Console.ReadKey();
        }

        // 강의 시간표 한줄 출력
        public void ShowCourse(int index)
        {
            PrintingCourse printingCourse = new PrintingCourse();
            printingCourse.PrintCourse(course[index].Major, course[index].CourseNumber, course[index].Distribution, course[index].Title, course[index].Sortation, course[index].Grade, course[index].Score, course[index].CourseTime, course[index].ClassRoom, course[index].Professor,course[index].Language);
        }
    }
}
