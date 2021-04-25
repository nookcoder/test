using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;

namespace LectureTimeTable2.LectureProperty
{
    class LectureMenu
    {
        private List<StudentsVO> students;
        private List<LecturesVO> courses;
        private List<StudentCourseVO> studentCourses;
        private LectureException lectureException;
        private Search Search;
        private LectureScreen lectureScreen;
        private LectureTable lectureTable;

        public LectureMenu(List<StudentsVO> students, List<LecturesVO> courses, List<StudentCourseVO> studentCourses)
        {
            this.students = students;
            this.courses = courses;
            this.studentCourses = studentCourses;
            
            this.lectureException = new LectureException();
            this.Search = new Search(students, courses, studentCourses);
            this.lectureScreen = new LectureScreen();
            this.lectureTable = new LectureTable();
        }

        // 강의시간표 조회 메뉴 실행 함수 
        public void RunLectureTableMenu()
        {
            int menu;
            string menuCheck;

            // 어떤 방식으로 검색할 것인 지 입력받기 
            lectureScreen.PrintLectureTimeTableMenu();
            lectureScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(lectureException.HandleLectureTimeTableMenuInput(menuCheck));
            
            // 메뉴 실행 
            switch(menu)
            {
                case Constants.MAJOR:
                    SearchByMajor();
                    break;
                case Constants.LECTURENUMBER:
                    break;
                case Constants.SUBJECTNAME:
                    break;
                case Constants.GRADE:
                    break;
                case Constants.PROFESSOR:
                    break;
                case Constants.BACK_TO_INITIALMENU:
                    break;
            }
        }

        // 전공으로 검색하기 
        public void SearchByMajor()
        {
            int menu;
            string menuCheck;

            // 찾는 전공 물어보기 
            lectureScreen.PrintMajorSearchMenu();
            lectureScreen.PrintMenuInput();
            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(lectureException.HandleSearchByMajor(menuCheck));

            // 해당 전공 강의 전체 출력
            switch (menu)
            {
                case Constants.COMPUTER:
                    lectureTable.LoadComputeMajor();
                    SearchByMajor();
                    break;

                case Constants.INTELLIGENCE:
                    lectureTable.LoadIntelligenceMajor();
                    SearchByMajor();
                    break;

                case Constants.ENGINEERING:
                    lectureTable.LoadEngineeringMajor();
                    SearchByMajor();
                    break;

                case Constants.BACK_TO_LECTURETABLEMENU:
                    RunLectureTableMenu();
                    break;

            }

        }
    }

    class Search
    {
        private List<StudentsVO> students;
        private List<LecturesVO> courses;
        private List<StudentCourseVO> studentCourses;

        private LectureScreen lectureScreen;
        private LectureTable lectureTable;
        private LectureException lectureException;
      

        public Search(List<StudentsVO> students, List<LecturesVO> courses, List<StudentCourseVO> studentCourses)
        {
            this.students = students;
            this.courses = courses;
            this.studentCourses = studentCourses;

            this.lectureScreen = new LectureScreen();
            this.lectureTable = new LectureTable();
            this.lectureException = new LectureException();;
        }
    }
}
