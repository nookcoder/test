using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.LectureProperty;
using LectureTimeTable2.AttentionProperty;
using LectureTimeTable2.Registeration;

namespace LectureTimeTable2.Login
{
    class Login : LoginScreen
    {
        private List<StudentsVO> students;
        private List<CourseVO> courses;
        private List<AttentionVO> attention;
        private List<RegistrationVO> registrations;
        
        private string id;
        private string idChecker;
        
        private string password;
        private string passwordChecker;

        public Login(List<StudentsVO> students, List<CourseVO> courses, List<AttentionVO> attention, List<RegistrationVO> registrations)
        {
            this.students = students;
            this.courses = courses;
            this.attention = attention;
            this.registrations = registrations;
        }

        // 로그인 실행 함수. 
        public void RunLogin()
        {
            LoginException loginException = new LoginException();
            
            PrintLTT();

            PrintId(null);

            // id 입력 받기 
            idChecker = Console.ReadLine();
            id = loginException.HandleIdException(idChecker);
        
            // password 입력 받기 
            PrintPassword(null);
            passwordChecker = Console.ReadLine();
            password = loginException.HandlePasswordException(id,passwordChecker);

            // id password 있는 지 확인 
            CheckId(id, password);
        }

        // 로그인 성공 실패 
        public void CheckId(string id, string password)
        {
            bool isNone = Constants.NONE;

            // 아이디가 있으면 메뉴를 출력하는 함수 호출
            for (int index = 0; index < students.Count; index++)
            { 
                if (id == students[index].StudentId && password == students[index].Password )
                {
                    InitialMenu initialMenu = new InitialMenu(students, courses, attention,registrations);
                    initialMenu.RunInitialMenu();
                    isNone = Constants.FIND;
                }
            }

            // 없을 때 입력 다시 받기
            if (isNone)
            {
                PrintNoExistId();
                Console.ReadKey();
                RunLogin();
            }
        }
    }

    // 초기 메뉴 화면 관련 클래스 
    class InitialMenu: LoginScreen
    {
        private List<StudentsVO> students;
        private List<CourseVO> lectures;
        private List<AttentionVO> attentions;
        private List<RegistrationVO> registrations;
        
        private LoginException loginException;
        private AttentionMenu AttentionMenu;
        private RegistrationMenu RegisterationMenu;
        public InitialMenu(List<StudentsVO> students, List<CourseVO> lectures, List<AttentionVO> attentions,List<RegistrationVO> registrations)
        {
            this.students = students;
            this.lectures = lectures;
            this.attentions = attentions;
            this.registrations = registrations;

            this.loginException = new LoginException();
            this.AttentionMenu = new AttentionMenu(students, lectures, attentions, this.registrations);
            this.RegisterationMenu = new RegistrationMenu(students, lectures, attentions, this.registrations);
        }

        // 초기 메뉴 실행 
        public void RunInitialMenu()
        { 

            CourseMenu courseMenu = new CourseMenu(students, lectures, attentions, registrations);
            
            int menu;
            string menuCheck;

            // 메뉴 입력 받기
            PrintInitialMenu();
            PrintInitialMenuInput();
            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(loginException.HandleInitialMenu(menuCheck));
            
            // 해당 메뉴로 이동 
            switch(menu)
            {

                case Constants.LECTURETIMETABLE:
                    courseMenu.RunLectureTableMenu();
                    break;

                case Constants.ATTENTION:
                    AttentionMenu.RunAttentionMenu();
                    break;

                case Constants.REGISTRATION:
                    RegisterationMenu.RunRegisterMenu();
                    break;
               
                case Constants.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
