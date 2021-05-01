using LectureTimeTable2.Login;
using LectureTimeTable2.VOs;
using System;
using System.Collections.Generic;
using LectureTimeTable2.TimeTable;

namespace LectureTimeTable2.AttentionProperty
{
    class AttentionMenu
    { 
        private List<CourseVO> course;
        private List<StudentsVO> students;
        private List<AttentionVO> attentions;
        private List<RegistrationVO> registrations;

        private AttentionScreen attentionScreen;
        private AttentionException attentionException;
        private UserTimeTable userTimeTable;

        public AttentionMenu(List<StudentsVO> students, List<CourseVO> course, List<AttentionVO> attentions, List<RegistrationVO> registrations)
        {
            this.course = course;
            this.attentions = attentions;
            this.students = students;
            this.registrations = registrations;
            this.attentionScreen = new AttentionScreen();
            this.attentionException = new AttentionException();
        }

        // 메뉴 입력 받기
        public int GetAttentionMenu()
        {
            string menuCheck;
            int menu;

            attentionScreen.PrintAttentionSearchMenu();
            attentionScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = attentionException.HandleAttentionMenuInupt(menuCheck);

            return menu;
        }

        // 메뉴 실행하기
        public void RunAttentionMenu()
        {
            int menu;
            InitialMenu InitialMenu = new InitialMenu(students, course, attentions, registrations);
            
            menu = GetAttentionMenu();

            switch (menu)
            {
                case Constants.ADD:
                    LoadCourseByCourseTitle();
                    break;

                case Constants.INQUIRY:
                    ShowAttentionCourse();
                    DeletAttentionCourse();
                    break;

                case Constants.BACK:
                    InitialMenu.RunInitialMenu();
                    break;
            }
        }

        // 교과목명 입력 받기(교과목 이름으로 검색)
        public string GetCourseTitle()
        {
            string courseTitleCheck;
            string courseTitle;

            Console.Clear();
            attentionScreen.PrintGetCourseTitle();
            courseTitleCheck = Console.ReadLine();
            courseTitle = attentionException.HandleAttentionCourseTitle(courseTitleCheck);

            return courseTitle;
        }

        // 해당 강의 시간표 불러오기 
        public bool IsCourseByCourseTitle()
        {
            string courseTitle;
            bool isFound = Constants.NONE;

            courseTitle = GetCourseTitle();
           
            for (int Index = 0; Index < 169; Index++)
            {
                if (course[Index].Title.Contains(courseTitle))
                {
                    isFound = Constants.FIND;
                    Console.Write(Index < 10 ? $"00{Index} " : Index < 100 ? $"0{Index} " : $"{Index} ");
                    ShowCourse(Index);
                }

            }

            if (isFound)
            {
                Console.Clear();
                attentionScreen.PrintNoFoundLecture();
                attentionScreen.PrintProgressNotice();
                Console.ReadKey();
            }

            return isFound;
        }
        
        public void LoadCourseByCourseTitle()
        {
            bool isFound;
            isFound = IsCourseByCourseTitle();
            
            if(isFound)
            {
                RunAttentionMenu();
            }

            else
            {
                AddAttentionCourse();
                RunAttentionMenu();
            }
        }

        // 관심과목  인덱스 입력받기
        public string GetAttentionCourseIndex()
        {
            string courseIndexCheck;
            string courseIndex;

            attentionScreen.PrintGetAttentionCourseNumber();
            courseIndexCheck = Console.ReadLine();
            courseIndex = attentionException.HandleAttentionCourseIndex(courseIndexCheck);

            return courseIndex;
        }

        // 관심과목 추가하기
        public void AddAttentionCourse()
        {
            string courseIndexString;
            int courseIndex;
            int credit;
            bool isFound = Constants.NONE;

            courseIndexString = GetAttentionCourseIndex();

            if(courseIndexString != "q")
            {
                credit = 0; 

                for(int index = 0; index < attentions.Count;index++)
                {
                    credit += attentions[index].Score;
                }

                // 신청 가능 학점을 초과하지 않을 때
                if (credit <= 24)
                {
                    courseIndex = Convert.ToInt32(courseIndexString);
                   
                    // 이미 담은 과목인지 확인
                    for(int index = 0; index < attentions.Count;index++)
                    {
                        if(course[courseIndex].CourseNumber == attentions[index].CourseNumber)
                        {
                            isFound = Constants.FIND; 
                        }
                    }
                    
                    // 담지 않은 과목이면 AttentionsVO 에 추가 
                    if (isFound)
                    {
                        attentions.Add(new AttentionVO(course[courseIndex].Major, course[courseIndex].CourseNumber, course[courseIndex].Distribution, course[courseIndex].Title, course[courseIndex].Sortation,
                                 course[courseIndex].Grade, course[courseIndex].Score, course[courseIndex].CourseTime, course[courseIndex].ClassRoom, course[courseIndex].Professor, course[courseIndex].Language));

                        attentionScreen.PrintAddNotice();
                        attentionScreen.PrintProgressNotice();
                        Console.ReadKey();
                        Console.SetWindowSize(100, 40);
                    }

                    else
                    {
                        attentionScreen.PrintOverlapCourse();
                        attentionScreen.PrintProgressNotice();
                        Console.ReadKey();
                        Console.SetWindowSize(100, 40);
                    }
                }

                // 수강가능학점을 초과 했을 때 
                else
                {
                    attentionScreen.PrintTooMuchCredit();
                    attentionScreen.PrintProgressNotice();
                    Console.ReadKey();
                    Console.SetWindowSize(100, 40); 
                }


            }

            else
            {
                RunAttentionMenu();
            }
        }  

        // 관심과목 조회 
        public void ShowAttentionCourse()
        {
            bool isFound = Constants.NONE;

            attentionScreen.PrintCourseLabel();
            
            for(int index = 0; index < attentions.Count; index++)
            {
                Console.Write(index+1 < 10 ? $"00{index+1} " : index < 100 ? $"0{index+1} " : $"{index+1} ");
                ShowAttentionCourse(index);
                isFound = Constants.FIND;
            }

            if(isFound)
            {
                Console.SetWindowSize(160, 40);
                attentionScreen.PrintProgressNotice();
                Console.ReadKey();
                Console.SetWindowSize(100, 40);
                RunAttentionMenu();
            }
        }

        // 삭제하고 싶은 관심과목 인댁스 입력받기 
        public string GetReviseAttentionCourse()
        {
            string attentionCourseIndexCheck;
            string attentionCourseIndex;

            attentionScreen.PrintGetReviseAttentionCourse();
            attentionCourseIndexCheck = Console.ReadLine();
            attentionCourseIndex = attentionException.HandleGetReviseAttentionCourse(attentionCourseIndexCheck);

            return attentionCourseIndex;
        }

        // 관심과목 삭제하기 
        public void DeletAttentionCourse()
        {
            string attentionCourseindexString;
            int attentionCourseindex;

            attentionCourseindexString = GetReviseAttentionCourse();
            
            if(attentionCourseindexString == "q")
            {
                Console.SetWindowSize(100, 40);
                RunAttentionMenu();
            }

            else
            {
                attentionCourseindex = Convert.ToInt32(attentionCourseindexString);
                
                if(attentions.Count >= attentionCourseindex)
                {
                    attentions.RemoveAt(attentionCourseindex - 1);
                    attentionScreen.PrintDeletNotice();
                    attentionScreen.PrintProgressNotice();
                    Console.ReadLine();
                    Console.SetWindowSize(100, 40);
                    RunAttentionMenu();
                }

                else
                {
                    attentionScreen.PrintNoFoundLecture();
                    attentionScreen.PrintProgressNotice();
                    Console.ReadLine();
                    Console.SetWindowSize(100, 40);RunAttentionMenu();
                }
            }
        }


        // 강의 출력 
        public void ShowCourse(int index)
        {
            PrintingCourse printingCourse = new PrintingCourse();
            printingCourse.PrintCourse(course[index].Major, course[index].CourseNumber, course[index].Distribution, course[index].Title, course[index].Sortation, course[index].Grade, course[index].Score, course[index].CourseTime, course[index].ClassRoom, course[index].Professor, course[index].Language);
        }

        // 관심 과목 강의 출력 
        public void ShowAttentionCourse(int index)
        {
            PrintingCourse printingCourse = new PrintingCourse();
            printingCourse.PrintCourse(attentions[index].Major, attentions[index].CourseNumber, attentions[index].Distribution, attentions[index].Title, attentions[index].Sortation, attentions[index].Grade, attentions[index].Score.ToString(), attentions[index].CourseTime, attentions[index].ClassRoom, attentions[index].Professor, attentions[index].Language);

        }
    }
}

