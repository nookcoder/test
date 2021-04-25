using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.VOs
{
    class StudentsVO
    {
        private string studentId ;
        private string password; 

        public StudentsVO(string studentId, string password)
        {
            this.studentId = studentId;
            this.password = password; 
        }

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public override string ToString()
        {
            return $"{studentId} {password}";
        }
    }
}
