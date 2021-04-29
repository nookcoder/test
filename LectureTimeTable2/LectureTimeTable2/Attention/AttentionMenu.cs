using LectureTimeTable2.Login;
using LectureTimeTable2.VOs;
using System;
using System.Collections.Generic;

namespace LectureTimeTable2.AttentionProperty
{
    class AttentionMenu
    { 
        private List<CourseVO> course;
        private List<StudentsVO> students;
        private List<AttentionVO> attentions;
        private List<RegistrationVO> registrations;

        private AttentionScreen AttentionScreen;
        private AttentionException AttentionException;

        public AttentionMenu(List<StudentsVO> students, List<CourseVO> course, List<AttentionVO> attentions, List<RegistrationVO> registrations)
        {
            this.course = course;
            this.attentions = attentions;
            this.students = students;
            this.AttentionScreen = new AttentionScreen();
            this.AttentionException = new AttentionException();
        }

        // 메뉴 입력 받기
        public int GetAttentionMenu()
        {
            string menuCheck;
            int menu;

            AttentionScreen.PrintAttentionSearchMenu();
            AttentionScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = AttentionException.HandleAttentionMenuInupt(menuCheck);

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
            AttentionScreen.PrintGetCourseTitle();
            courseTitleCheck = Console.ReadLine();
            courseTitle = AttentionException.HandleAttentionCourseTitle(courseTitleCheck);

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
                AttentionScreen.PrintNoFoundLecture();
                AttentionScreen.PrintProgressNotice();
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

            AttentionScreen.PrintGetAttentionCourseNumber();
            courseIndexCheck = Console.ReadLine();
            courseIndex = AttentionException.HandleAttentionCourseIndex(courseIndexCheck);

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
                        if(course[courseIndex - 1].CourseNumber == attentions[index].CourseNumber && course[courseIndex - 1].Distribution == attentions[index].Distribution)
                        {
                            isFound = Constants.FIND; 
                        }
                    }
                    
                    // 담지 않은 과목이면 AttentionsVO 에 추가 
                    if (isFound)
                    {
                        attentions.Add(new AttentionVO(course[courseIndex - 1].Major, course[courseIndex - 1].CourseNumber, course[courseIndex - 1].Distribution, course[courseIndex - 1].Title, course[courseIndex - 1].Sortation,
                                 course[courseIndex - 1].Grade, course[courseIndex - 1].Score, course[courseIndex - 1].CourseTime, course[courseIndex - 1].ClassRoom, course[courseIndex - 1].Professor, course[courseIndex - 1].Language));

                        AttentionScreen.PrintAddNotice();
                        AttentionScreen.PrintProgressNotice();
                        Console.ReadKey();
                        Console.SetWindowSize(100, 40);
                    }

                    else
                    {
                        AttentionScreen.PrintOverlapCourse();
                        AttentionScreen.PrintProgressNotice();
                        Console.ReadKey();
                        Console.SetWindowSize(100, 40);
                    }
                }

                // 수강가능학점을 초과 했을 때 
                else
                {
                    AttentionScreen.PrintTooMuchCredit();
                    AttentionScreen.PrintProgressNotice();
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

            AttentionScreen.PrintCourseLabel();
            
            for(int index = 0; index < attentions.Count; index++)
            {
                Console.Write(index+1 < 10 ? $"00{index+1} " : index < 100 ? $"0{index+1} " : $"{index+1} ");
                ShowAttentionCourse(index);
                isFound = Constants.FIND;
            }

            if(isFound)
            {
                Console.SetWindowSize(160, 40);
                AttentionScreen.PrintProgressNotice();
                Console.ReadKey();
                RunAttentionMenu();
            }
        }

        // 삭제하고 싶은 관심과목 인댁스 입력받기 
        public string GetReviseAttentionCourse()
        {
            string attentionCourseIndexCheck;
            string attentionCourseIndex;

            AttentionScreen.PrintGetReviseAttentionCourse();
            attentionCourseIndexCheck = Console.ReadLine();
            attentionCourseIndex = AttentionException.HandleGetReviseAttentionCourse(attentionCourseIndexCheck);

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
                RunAttentionMenu();
            }

            else
            {
                attentionCourseindex = Convert.ToInt32(attentionCourseindexString);
                
                if(attentions.Count >= attentionCourseindex)
                {
                    attentions.RemoveAt(attentionCourseindex - 1);
                    AttentionScreen.PrintProgressNotice();
                    AttentionScreen.PrintDeletNotice();
                    Console.ReadLine();
                    RunAttentionMenu();
                }

                else
                {
                    AttentionScreen.PrintNoFoundLecture();
                    AttentionScreen.PrintProgressNotice();
                    Console.ReadLine();
                    RunAttentionMenu();
                }
            }
        }


        // 강의 출력 
        public void ShowCourse(int index)
        {
            Console.SetWindowSize(160, 40);
            Console.Write(" " + course[index].Major.PadRight(20 - course[index].Major.Length) + " ");
            Console.Write(course[index].CourseNumber.PadRight(2) + " ");
            Console.Write(course[index].Distribution.PadRight(2) + " ");
            Console.Write(course[index].Title.PadRight(34 - course[index].Title.Length) + " ");
            Console.Write(course[index].Sortation + " ");
            Console.Write(course[index].Grade + " ");
            Console.Write(course[index].Score + " ");
            Console.Write(course[index].CourseTime + " ");
            Console.Write(course[index].ClassRoom + " ");
            Console.Write(course[index].Professor + " ");
            Console.Write(course[index].Language + " ");
            Console.WriteLine("\n");

        }

        // 관심 과목 강의 출력 
        public void ShowAttentionCourse(int index)
        {
            Console.SetWindowSize(160, 40);
            Console.Write(" " + course[index].Major.PadRight(20 - course[index].Major.Length) + " ");
            Console.Write(attentions[index].CourseNumber.PadRight(2) + " ");
            Console.Write(attentions[index].Distribution.PadRight(2) + " ");
            Console.Write(attentions[index].Title.PadRight(34 - course[index].Title.Length) + " ");
            Console.Write(attentions[index].Sortation + " ");
            Console.Write(attentions[index].Grade + " ");
            Console.Write(attentions[index].Score + " ");
            Console.Write(attentions[index].CourseTime + " ");
            Console.Write(attentions[index].ClassRoom + " ");
            Console.Write(attentions[index].Professor + " ");
            Console.Write(attentions[index].Language + " ");
            Console.WriteLine("\n");
        }
    }
}

