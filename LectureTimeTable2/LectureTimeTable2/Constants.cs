using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2
{
    class Constants
    {
        // bool형 Constants
        public const bool ERROR = true; 
        public const bool NOERROR = false;
        public const bool NONE = true;
        public const bool FIND = false;

        // InitialMenu Constants
        public const int LECTURETIMETABLE = 1;
        public const int ATTENTION = 2;
        public const int APPLICATION = 3;
        public const int CHECKINGCOURSE = 4;
        public const int CHECKINGTIMETABLE = 5;
        public const int Exit = 6;

        // LectureTimeTableMenu Constants
        public const int MAJOR = 1;
        public const int LECTURENUMBER = 2;
        public const int SUBJECTNAME = 3; 
        public const int GRADE = 4;
        public const int PROFESSOR = 5;
        public const int BACK_TO_INITIALMENU = 6;

        // MajorMenu Constants
        public const int COMPUTER = 1;
        public const int INTELLIGENCE = 2;
        public const int ENGINEERING = 3;
        public const int BACK_TO_LECTURETABLEMENU = 4;

        // 관심과목 담기 메뉴 
        public const int ADD = 1;
        public const int INQUIRY = 2;
        public const int BACK = 3;
    }
}
