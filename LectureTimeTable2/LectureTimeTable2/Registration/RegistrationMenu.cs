using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.Login;
using LectureTimeTable2.Registration;
using LectureTimeTable2.TimeTable;

namespace LectureTimeTable2.Registeration
{
    class RegistrationMenu
    {
        private List<StudentsVO> students;
        private List<CourseVO> course;
        private List<AttentionVO> attentions;
        private List<RegistrationVO> registrations;

        private RegistrationException registrationException;
        private RegistrationScreen registrationScreen;
        private UserTimeTable userTimeTable;

        public RegistrationMenu(List<StudentsVO> students, List<CourseVO> course, List<AttentionVO> attentions, List<RegistrationVO> registrations)
        {
            this.students = students;
            this.course = course;
            this.attentions = attentions;
            this.registrations = registrations;

            this.registrationException = new RegistrationException();
            this.registrationScreen = new RegistrationScreen();
        }

        // 수강 신청 메뉴 고르기 
        public int GetRegisterMenu()
        {
            string menuCheck;
            int menu;

            registrationScreen.PrintRegistrationMenu();
            registrationScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = registrationException.HandleGetRegistrationMenu(menuCheck);

            return menu;
        }

        // 수강 신청 메뉴 실행 
        public void RunRegisterMenu()
        {
            int menu;

            menu = GetRegisterMenu();

            switch (menu)
            {
                case Constants.ATTENTIONREGISTER:
                    RegisterCourseFromAttention();
                    break;

                case Constants.REGISTERBYSEARCH:
                    RegisterCourseFromTitle();
                    break;

                case Constants.REVISE_REGISTRATION:
                    RunReviseRegistrationCourse();
                    break;

                case Constants.REGISTER_BACK:
                    InitialMenu initialMenu = new InitialMenu(students, course, attentions, registrations);
                    initialMenu.RunInitialMenu();
                    break;
            }
        }


        // 관심 과목 조회 / 추가 
        // 관심과목 불러오기 
        public void LoadAttentionCourse()
        {
            Console.Clear();
            registrationScreen.PrintCourseLabel();
            Console.SetWindowSize(160, 40);
            for (int index = 0; index < attentions.Count; index++)
            {
                Console.Write(index + 1 < 10 ? $"00{index + 1}" : $"0{index + 1}");
                ShowAttentionCourse(index);
            }
        }

        // 수강 신청 과목 불러오기 
        public void LoadRegistrationCourse()
        {
            int credit = 0;

            registrationScreen.PrintRegisterListLabel();
            registrationScreen.PrintCourseLabel();
            Console.SetWindowSize(160, 40);

            for (int index = 0; index < registrations.Count; index++)
            {
                Console.Write(index + 1 < 10 ? $"00{index + 1}" : $"0{index + 1}");
                ShowRegistrationCourse(index);
            }

            registrationScreen.PrintCreditLabel();
            for (int index = 0; index < registrations?.Count; index++)
            {
                credit += Convert.ToInt32(registrations[index].Credit);
            }
            Console.WriteLine(credit);

        }


        // 검색해서 수강신청하기 
        public void RegisterCourseFromAttention()
        {
            string courseIndexString;
            int courseIndex;

            LoadAttentionCourse();
            if (registrations?.Count != 0)
            {
                LoadRegistrationCourse();
            }

            courseIndexString = GetRegisterIndex();

            // 종료 버튼이 입력 됐을 때 
            if (courseIndexString == "q")
            {
                RunRegisterMenu();
            }

            // 강의 번호를 입력했을 때 
            else
            {
                courseIndex = Convert.ToInt32(courseIndexString);

                // 수강 신청 가능 학점을 넘었는 지 확인 
                if (IsOverCredit())
                {
                    registrationScreen.PrintTooMuchCredit();
                    registrationScreen.PrintProgressNotice();
                    Console.ReadKey();
                    Console.SetWindowSize(100, 40);
                    RunRegisterMenu();
                }

                else
                {
                    // 똑같은 강의를 신청했는 지 확인 
                    if (IsAlreayHaveForAll(courseIndex))
                    {
                        registrationScreen.PrintOverlapCourse();
                        registrationScreen.PrintProgressNotice();
                        Console.ReadKey();
                        Console.SetWindowSize(100, 40);
                        RunRegisterMenu();
                    }

                    else
                    {
                        // 강의시간이 겹치지 않을 때 
                        if (IsTimeOverlapForAll(courseIndex))
                        {
                            registrations.Add(new RegistrationVO(attentions[courseIndex - 1].Major, attentions[courseIndex - 1].CourseNumber, attentions[courseIndex - 1].Distribution, attentions[courseIndex - 1].Title, attentions[courseIndex - 1].Sortation,
                                       attentions[courseIndex - 1].Grade, attentions[courseIndex - 1].Score, attentions[courseIndex - 1].CourseTime, attentions[courseIndex - 1].ClassRoom, attentions[courseIndex - 1].Professor, attentions[courseIndex - 1].Language));
                            registrationScreen.PrintAddNotice();
                            registrationScreen.PrintProgressNotice();
                            Console.ReadKey();
                            Console.SetWindowSize(100, 40);
                            RunRegisterMenu();
                        }

                        else
                        {
                            registrationScreen.PrintTimeOverlap();
                            registrationScreen.PrintProgressNotice();
                            Console.ReadKey();
                            Console.SetWindowSize(100, 40);
                            RunRegisterMenu();
                        }
                    }
                }
            }

        }


        // 강의 검색 / 추가   
        // 교과목명 입력 받기(교과목 이름으로 검색)
        public string GetCourseTitle()
        {
            string courseTitleCheck;
            string courseTitle;

            Console.Clear();
            registrationScreen.PrintGetCourseTitle();
            courseTitleCheck = Console.ReadLine();
            courseTitle = registrationException.HandleRegisterCourseTitle(courseTitleCheck);

            return courseTitle;
        }

        // 검색 과목 출력하기 
        public bool IsHaveCourseByTitle()
        {
            string courseTitle;
            bool IsHave = Constants.NONE;

            courseTitle = GetCourseTitle();
            registrationScreen.PrintCourseLabel();
            Console.SetWindowSize(160, 40);
            for (int Index = 0; Index < 169; Index++)
            {
                if (course[Index].Title.Contains(courseTitle))
                {
                    IsHave = Constants.FIND;
                    Console.Write(Index < 10 ? $"00{Index} " : Index < 100 ? $"0{Index} " : $"{Index} ");
                    ShowALLCourse(Index);
                }

            }

            if (IsHave)
            {
                Console.Clear();
                registrationScreen.PrintNoFoundCourse();
                registrationScreen.PrintProgressNotice();
                Console.ReadKey();
            }

            return IsHave;
        }

        // 관심과목에서 수강신청하기 
        public void RegisterCourseFromTitle()
        {
            string courseIndexString;
            int courseIndex;
            bool isHave;

            isHave = IsHaveCourseByTitle();
            if (isHave)
            {
                Console.SetWindowSize(100, 40);
                RunRegisterMenu();
            }

            else
            {
                courseIndexString = GetRegisterIndex();

                // 종료 버튼이 입력 됐을 때 
                if (courseIndexString == "q")
                {
                    Console.SetWindowSize(100, 40);
                    RunRegisterMenu();
                }

                // 강의 번호를 입력했을 때 
                else
                {
                    courseIndex = Convert.ToInt32(courseIndexString);

                    // 수강 신청 가능 학점을 넘었는 지 확인 
                    if (IsOverCredit())
                    {
                        registrationScreen.PrintTooMuchCredit();
                        registrationScreen.PrintProgressNotice();
                        Console.ReadKey();
                        Console.SetWindowSize(100, 40);
                        RunRegisterMenu();
                    }

                    else
                    {
                        // 똑같은 강의를 신청했는 지 확인 
                        if (IsAlreayHaveForAll(courseIndex))
                        {
                            registrationScreen.PrintOverlapCourse();
                            registrationScreen.PrintProgressNotice();
                            Console.ReadKey();
                            Console.SetWindowSize(100, 40);
                            RunRegisterMenu();
                        }

                        else
                        {
                            // 강의시간이 겹치지 않을 때 
                            if (IsTimeOverlapForAll(courseIndex))
                            {
                                registrations.Add(new RegistrationVO(course[courseIndex].Major, course[courseIndex].CourseNumber, course[courseIndex].Distribution, course[courseIndex].Title, course[courseIndex].Sortation,
                                           course[courseIndex].Grade, course[courseIndex].Score, course[courseIndex].CourseTime, course[courseIndex].ClassRoom, course[courseIndex].Professor, course[courseIndex].Language));
                                registrationScreen.PrintAddNotice();
                                registrationScreen.PrintProgressNotice();
                                Console.ReadKey();
                                Console.SetWindowSize(100, 40);
                                RunRegisterMenu();
                            }

                            else
                            {
                                registrationScreen.PrintTimeOverlap();
                                registrationScreen.PrintProgressNotice();
                                Console.ReadKey();
                                Console.SetWindowSize(100, 40);
                                RunRegisterMenu();
                            }
                        }
                    }
                }
            }
        }


        //강의 조회/삭제 
        public void RunReviseRegistrationCourse()
        {
            if (registrations.Count != 0)
            {
                Console.Clear();
                LoadRegistrationCourse();
                DeletRegistrationCourse();
            }

            else
            {
                registrationScreen.PrintNoRegistration();
                registrationScreen.PrintProgressNotice();
                Console.ReadKey();
                Console.SetWindowSize(100, 40);
                RunRegisterMenu();
            }
        }

        // 삭제하고 싶은 강의 물어보기 
        public string GetDeletIndex()
        {
            string courseIndexCheck;
            string courseIndex;

            registrationScreen.PrintGetRegisterCourseNumber();
            courseIndexCheck = Console.ReadLine();
            courseIndex = registrationException.HandleGetDeletCourse(courseIndexCheck);

            return courseIndex;
        }

        // 수강 신청 강의 삭제하기 
        public void DeletRegistrationCourse()
        {
            string courseIndexString;
            int courseIndex;

            courseIndexString = GetDeletIndex();

            if (courseIndexString == "q")
            {
                Console.SetWindowSize(100, 40);
                RunRegisterMenu();
            }

            else
            {
                courseIndex = Convert.ToInt32(courseIndexString);

                if (registrations.Count >= courseIndex)
                {
                    registrations.RemoveAt(courseIndex - 1);
                    registrationScreen.PrintDeletNotice();
                    registrationScreen.PrintProgressNotice();
                    Console.ReadLine();
                    Console.SetWindowSize(100, 40);
                    RunRegisterMenu();
                }

                else
                {
                    registrationScreen.PrintNoFoundLecture();
                    registrationScreen.PrintProgressNotice();
                    Console.ReadLine();
                    Console.SetWindowSize(100, 40);
                    RunRegisterMenu();
                }
            }
        }

        // 수강신청하고 싶은 강의 물어보기 
        public string GetRegisterIndex()
        {
            string courseIndexCheck;
            string courseIndex;

            registrationScreen.PrintGetRegisterCourseNumber();
            courseIndexCheck = Console.ReadLine();
            courseIndex = registrationException.HandleRegisterCourseIndexByTitle(courseIndexCheck);

            return courseIndex;
        }

        // 학점 초과인지 확인 
        public bool IsOverCredit()
        {
            int credit = 0;
            bool isOver = false;

            for (int index = 0; index < registrations?.Count; index++)
            {
                credit += Convert.ToInt32(registrations[index].Credit);
            }

            if (credit >= 21)
            {
                isOver = true;
            }

            return isOver;
        }

        // 중복된 과목인지 확인
        public bool IsAlreayHaveForAttention(int index)
        {
            bool isHave = false;
            for (int registerIndex = 0; registerIndex < registrations?.Count; registerIndex++)
            {
                if (registrations[registerIndex].Major == attentions[index - 1].Major &&
                    registrations[registerIndex].CourseNumber == attentions[index - 1].CourseNumber &&
                    registrations[registerIndex].Sortation == attentions[index - 1].Sortation)
                {
                    isHave = true;
                }
            }

            return isHave;
        }

        public bool IsAlreayHaveForAll(int index)
        {
            bool isHave = false;
            for (int registerIndex = 0; registerIndex < registrations?.Count; registerIndex++)
            {
                if (registrations[registerIndex].Major == course[index - 1].Major &&
                    registrations[registerIndex].CourseNumber == course[index - 1].CourseNumber &&
                    registrations[registerIndex].Sortation == course[index - 1].Sortation)
                {
                    isHave = true;
                }
            }

            return isHave;
        }

        // 시간이 겹치는 지 확인
        public bool IsTimeOverlapForAttention(int index)
        {
            bool isRegister = Constants.DO_REGISTER;

            JugementOfOverlapedTime jugementOfOverlapedTime = new JugementOfOverlapedTime();
            isRegister = jugementOfOverlapedTime.IsRegister(registrations, attentions[index - 1].CourseTime);

            return isRegister;
        }

        public bool IsTimeOverlapForAll(int index)
        {
            bool isRegister = Constants.DO_REGISTER;

            JugementOfOverlapedTime jugementOfOverlapedTime = new JugementOfOverlapedTime();
            isRegister = jugementOfOverlapedTime.IsRegister(registrations, course[index - 1].CourseTime);

            return isRegister;
        }

        // 전체 강의 출력 
        public void ShowALLCourse(int index)
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

        // 수강 신청 강의 출력
        public void ShowRegistrationCourse(int index)
        {
            PrintingCourse printingCourse = new PrintingCourse();
            printingCourse.PrintCourse(registrations[index].Major, registrations[index].CourseNumber, registrations[index].Distribution, registrations[index].Title, registrations[index].Sortation, registrations[index].Grade, registrations[index].Credit.ToString(), registrations[index].CourseTime, registrations[index].ClassRoom, registrations[index].Professor, registrations[index].Language);

        }
    }
} 
