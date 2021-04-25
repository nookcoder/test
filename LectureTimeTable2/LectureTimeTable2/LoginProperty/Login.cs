using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.LectureProperty;

namespace LectureTimeTable2.Login
{
    class Login : LoginScreen
    {
        private List<StudentsVO> students;
        private List<LecturesVO> courses;
        private List<StudentCourseVO> studentCourses;
        
        private string id;
        private string idChecker;
        
        private string password;
        private string passwordChecker;

        public Login(List<StudentsVO> students, List<LecturesVO> courses, List<StudentCourseVO> studentCourses)
        {
            this.students = students;
            this.courses = courses;
            this.studentCourses = studentCourses;
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
                    InitialMenu initialMenu = new InitialMenu(students, courses, studentCourses);
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
        private List<LecturesVO> lectures;
        private List<StudentCourseVO> studentCourses;
        private LoginException loginException;
        
        public InitialMenu(List<StudentsVO> students, List<LecturesVO> lectures, List<StudentCourseVO> studentCourses)
        {
            this.students = students;
            this.lectures = lectures;
            this.studentCourses = studentCourses;

            this.loginException = new LoginException();
        }

        // 초기 메뉴 실행 
        public void RunInitialMenu()
        { 

            LectureMenu lectureMenu = new LectureMenu(students, lectures, studentCourses);
            
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
                    lectureMenu.RunLectureTableMenu();
                    break;

                case Constants.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
