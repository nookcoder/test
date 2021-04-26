using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.Login;
using Excel = Microsoft.Office.Interop.Excel;
using LectureTimeTable2.LectureProperty;

namespace LectureTimeTable2
{
    class Run
    {
        public List<StudentsVO> students;
        public List<CourseVO> courses;
        public List<StudentCourseVO> studentCourses;

        private CourseScreen LectureScreen = new CourseScreen();

        public Run()
        {
            Console.SetWindowSize(100, 40);

            this.students = new List<StudentsVO>();
            this.courses = new List<CourseVO>();
            this.studentCourses = new List<StudentCourseVO>();
            students.Add(new StudentsVO("18011250", "ensharp21"));

            InputLectureInVO();
        }

        public void RunProgram()
        {
            Login.Login login = new Login.Login(students, courses, studentCourses);
            login.RunLogin();
        }
        
        public void InputLectureInVO()
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2021년도 1학기 강의시간표.xlsx");
            Excel.Sheets sheets = workbook.Sheets;
            Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;
            Excel.Range cellRange = worksheet.get_Range("B2", "L170") as Excel.Range;
            Array data = (Array)cellRange.Cells.Value2;

            for (int row = 1; row <= 169; row++)
            {
                courses.Add(new CourseVO(data.GetValue(row, 1), data.GetValue(row, 2), data.GetValue(row, 3), data.GetValue(row, 4), data.GetValue(row, 5), data.GetValue(row, 6), data.GetValue(row, 7), data.GetValue(row, 8), data.GetValue(row, 9), data.GetValue(row, 10), data.GetValue(row, 11)));
            }

        }
    }
}
