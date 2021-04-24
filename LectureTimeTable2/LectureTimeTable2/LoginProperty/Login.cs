using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;

namespace LectureTimeTable2.Login
{
    class LoginPractice : LoginScreen
    {
        private List<StudentsVO> students;
        private List<CoursesVO> courses;
        private List<StudentCourseVO> studentCourses;
        
        private string id;
        private string idChecker;
        
        private string password;
        private string passwordChecker;

        public LoginPractice(List<StudentsVO> students, List<CoursesVO> courses, List<StudentCourseVO> studentCourses)
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

    class InitialMenu: LoginScreen
    {
        private List<StudentsVO> students;
        private List<CoursesVO> courses;
        private List<StudentCourseVO> studentCourses;

        public InitialMenu(List<StudentsVO> students, List<CoursesVO> courses, List<StudentCourseVO> studentCourses)
        {
            this.students = students;
            this.courses = courses;
            this.studentCourses = studentCourses;
            RunInitialMenu();
        }

        public void RunInitialMenu()
        {
            LoginException loginException = new LoginException();

            int menu;
            string menuCheck;

            PrintInitialMenu();
            PrintInitialMenuInput();
            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(loginException.HandleInitialMenu(menuCheck));
            //ExecuteMenu(menu);
        }

        public void ExecuteMenu(int menu)
        {
            switch(menu)
            {
                case Constants.LECTURETIMETABLE:
                    
                    break;

                case Constants.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
