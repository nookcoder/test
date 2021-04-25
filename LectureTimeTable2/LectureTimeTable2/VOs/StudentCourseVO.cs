using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.VOs
{
    class StudentCourseVO
    {
        List<StudentsVO> studentsVOs;
        List<LecturesVO> lecturesVOs;

        public StudentCourseVO(List<StudentsVO> studentsVOs, List<LecturesVO> coursesVOs)
        {
            this.studentsVOs = studentsVOs;
            this.lecturesVOs = coursesVOs;
        }

        public StudentCourseVO(List<StudentsVO> studentsVOs)
        {
            this.studentsVOs = studentsVOs;
        }

        public StudentCourseVO(List<LecturesVO> lecturesVOs)
        {
            this.lecturesVOs = lecturesVOs;
        }

        public List<StudentsVO> Students
        {
            get { return studentsVOs; }
            set { studentsVOs = value; }
        }
    }
}
