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

        public override string ToString()
        {
            return $"{studentId} {password}";
        }
    }
}
