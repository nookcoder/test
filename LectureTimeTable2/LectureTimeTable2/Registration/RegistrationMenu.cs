using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.Login;
using LectureTimeTable2.Registration;

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

                case Constants.REGISTER_BACK:
                    InitialMenu initialMenu = new InitialMenu(students, course, attentions, registrations);
                    initialMenu.RunInitialMenu();
                    break;
            }
        }

        // 관심과목 불러오기 
        public void LoadAttentionCourse()
        {
            Console.Clear();
            registrationScreen.PrintCourseLabel();
            Console.SetWindowSize(160, 40);
            for (int index = 0; index < attentions.Count; index++)
            {
                Console.Write(index+1 < 10 ? $"00{index+1}" : $"0{index+1}");
                ShowCourse(index);
            }
        }

        // 수강신청하고 싶은 강의 물어보기 
        public string GetRegisterIndex()
        {
            string courseIndexCheck;
            string courseIndex;

            registrationScreen.PrintGetRegisterCourseNumber();
            courseIndexCheck = Console.ReadLine();
            courseIndex = registrationException.HandleGetReviseAttentionCourse(courseIndexCheck);

            return courseIndex;
        }

        // 관심과목에서 수강신청하기 
        public void RegisterCourseFromAttention()
        {
            string courseIndexString;
            int courseIndex;

            LoadAttentionCourse();

            courseIndexString = GetRegisterIndex();
            courseIndex = Convert.ToInt32(courseIndexString);
            
            // 수강 신청 가능 학점을 넘었는 지 확인 
            if(IsOverCredit())
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
                if(IsAlreayHave(courseIndex))
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
                    if (IsTimeOverlap(courseIndex))
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

        // 학점 초과인지 확인 
        public bool IsOverCredit()
        {
            int credit = 0;
            bool isOver = false;

            for(int index = 0; index < registrations?.Count; index++)
            {
                credit += Convert.ToInt32(registrations[index].Credit); 
            }

            if(credit >= 21)
            {
                isOver = true;
            }

            return isOver;
        }

        // 중복된 과목인지 확인
        public bool IsAlreayHave(int index)
        {
            bool isHave = false;
            for (int registerIndex = 0; registerIndex < registrations?.Count; registerIndex++)
            {
                if (registrations[registerIndex].Major == attentions[index-1].Major &&
                    registrations[registerIndex].CourseNumber == attentions[index-1].CourseNumber &&
                    registrations[registerIndex].Sortation == attentions[index-1].Sortation)
                {
                    isHave = true;
                }
            }

            return isHave;
        }

        // 시간이 겹치는 지 확인
        public bool IsTimeOverlap(int index)
        {
            bool isRegister = Constants.DO_REGISTER;

            JugementOfOverlapedTime jugementOfOverlapedTime = new JugementOfOverlapedTime();
            isRegister = jugementOfOverlapedTime.IsRegister(registrations, attentions[index-1].CourseTime);

            return isRegister;
        }
        
        // 강의 출력
        public void ShowCourse(int index)
        {
            Console.Write(" " + attentions[index].Major.PadRight(20 - attentions[index].Major.Length) + " ");
            Console.Write(attentions[index].CourseNumber.PadRight(2) + " ");
            Console.Write(attentions[index].Distribution.PadRight(2) + " ");
            Console.Write(attentions[index].Title.PadRight(34 - attentions[index].Title.Length) + " ");
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