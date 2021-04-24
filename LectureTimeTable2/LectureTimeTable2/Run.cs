using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;
using LectureTimeTable2.Login;

namespace LectureTimeTable2
{
    class Run
    {
        List<StudentsVO> students;
        List<CoursesVO> courses;
        List<StudentCourseVO> studentCourses;
       
        public Run()
        {
            Console.SetWindowSize(100, 40);

            this.students = new List<StudentsVO>();
            this.courses = new List<CoursesVO>();
            this.studentCourses = new List<StudentCourseVO>();
            students.Add(new StudentsVO("18011250", "ensharp21"));
            RunPrrogram();
        }

        public void RunPrrogram()
        {
            Login.Login loginPractice = new Login.Login(students, courses, studentCourses);
            loginPractice.RunLogin();
        }
    }
}
