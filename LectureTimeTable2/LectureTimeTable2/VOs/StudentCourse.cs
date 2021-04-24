using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.VOs
{
    class StudentCourse
    {
        List<StudentsVO> studentsVOs;
        List<CoursesVO> coursesVOs;

        public StudentCourse(List<StudentsVO> studentsVOs, List<CoursesVO> coursesVOs)
        {
            this.studentsVOs = studentsVOs;
            this.coursesVOs = coursesVOs;
        }
    }
}
