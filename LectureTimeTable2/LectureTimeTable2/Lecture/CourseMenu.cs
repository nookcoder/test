using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.Login;

namespace LectureTimeTable2.LectureProperty
{
    class CourseMenu
    {
        private List<StudentsVO> students;
        private List<CourseVO> courses;
        private List<AttentionVO> attention;
        private List<RegistrationVO> registrations;

        private CourseException courseException;
        private CourseScreen courseScreen;
        private InitialMenu initialMenu;

        private LoadingCourse loadingCourse;

        public CourseMenu(List<StudentsVO> students, List<CourseVO> courses, List<AttentionVO> attention,List<RegistrationVO> registrations)
        {
            this.students = students;
            this.courses = courses;
            this.attention = attention;
            this.registrations = registrations;


            this.courseException = new CourseException();
            this.courseScreen = new CourseScreen();
            this.initialMenu = new InitialMenu(this.students, this.courses,this.attention, this.registrations);

            this.loadingCourse = new LoadingCourse(courses);
        }

        // 강의시간표 조회 메뉴 실행 함수 
        public void RunLectureTableMenu()
        {
            int menu;
            string menuCheck;

            // 어떤 방식으로 검색할 것인 지 입력받기 
            courseScreen.PrintCourseTimeTableMenu();
            courseScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(courseException.HandleLectureTimeTableMenuInput(menuCheck));
            
            // 메뉴 실행 
            switch(menu)
            {
                case Constants.MAJOR:
                    SearchByMajor();
                    break;

                case Constants.LECTURENUMBER:
                    SearchByCourseNumber(); 
                    break;

                case Constants.SUBJECTNAME:
                    SearchBySubjectName();
                    break;

                case Constants.GRADE:
                    SearchByGrade();
                    break;

                case Constants.PROFESSOR:
                    SearchByProfessor();
                    break;

                case Constants.ALL:
                    SearchALL();
                    break;

                case Constants.BACK_TO_INITIALMENU:
                    initialMenu.RunInitialMenu();
                    break;
            }
        }

        // 전공으로 검색하기 
        public void SearchByMajor()
        {
            int menu;
            string menuCheck;

            // 찾는 전공 물어보기 
            courseScreen.PrintMajorSearchMenu();
            courseScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(courseException.HandleSearchByMajor(menuCheck));

            // 해당 전공 강의 전체 출력
            switch (menu)
            {
                case Constants.COMPUTER:
                    loadingCourse.LoadComputeMajor();
                    SearchByMajor();
                    break;

                case Constants.INTELLIGENCE:
                    loadingCourse.LoadIntelligenceMajor();
                    SearchByMajor();
                    break;

                case Constants.ENGINEERING:
                    loadingCourse.LoadEngineeringMajor();
                    SearchByMajor();
                    break;

                case Constants.BACK_TO_LECTURETABLEMENU:
                    RunLectureTableMenu();
                    break;

            }

        }

        // 학수 번호로 강의 찾기 
        public void SearchByCourseNumber()
        {
            string courseNumberCheck;
            string courseNumber;
            string distributionCheck;
            string distribution; 

            courseScreen.PrintExitNotice();
            courseScreen.PrintGetCourseNumber(null);
            courseNumberCheck = Console.ReadLine();
            courseNumber = courseException.HnadleGetCourseNumber(courseNumberCheck);

            courseScreen.PrintGetDistribution();
            distributionCheck = Console.ReadLine();
            distribution = courseException.HnadleGetDistribution(distributionCheck, courseNumber);
            Console.Clear();
            loadingCourse.LoadCourseByCourseNumber(courseNumber, distribution);
            Console.SetWindowSize(100, 40);
            RunLectureTableMenu();
        }

        // 교과명 검색 
        public void SearchBySubjectName()
        {
            string subjectNameCheck;
            string subjectName;

            Console.Clear();
            courseScreen.PrintGetSubjectName();
            subjectNameCheck = Console.ReadLine();
            subjectName = courseException.HandleGetSubjectName(subjectNameCheck);
            loadingCourse.LoadCourseBySubjectName(subjectName);
            Console.SetWindowSize(100, 40);
            RunLectureTableMenu();
        }

        // 학년으로 검색 
        public void SearchByGrade()
        {
            string gradeCheck;
            string grade;

            Console.Clear();
            courseScreen.PrintGetGrade();
            gradeCheck = Console.ReadLine();
            grade = courseException.HandleGetGrade(gradeCheck);
            Console.Clear(); 
            loadingCourse.LoadCourseByGrade(grade);
            Console.SetWindowSize(100, 40);
            RunLectureTableMenu();
        }

        // 교수명으로 강의 찾기
        public void SearchByProfessor()
        {
            string professorCheck;
            string professor;

            Console.Clear();
            courseScreen.PrintGetProfessor();
            professorCheck = Console.ReadLine();
            professor = courseException.HandleGetProfessorName(professorCheck);

            Console.Clear();
            loadingCourse.LoadCourseByProfessorName(professor);
            Console.SetWindowSize(100, 40);
            RunLectureTableMenu();
        }

        // 강의 시간표 전체 출력
        public void SearchALL()
        {
            Console.Clear();
            loadingCourse.LoadAllCourse();
            Console.SetWindowSize(100, 40);
            RunLectureTableMenu();
        }
    }

}
