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
        public const int REGISTRATION = 3;
        public const int CHECKINGTIMETABLE = 4;
        public const int Exit = 5;

        // LectureTimeTableMenu Constants
        public const int MAJOR = 1;
        public const int LECTURENUMBER = 2;
        public const int SUBJECTNAME = 3; 
        public const int GRADE = 4;
        public const int PROFESSOR = 5;
        public const int ALL = 6;
        public const int BACK_TO_INITIALMENU = 7;

        // MajorMenu Constants
        public const int COMPUTER = 1;
        public const int INTELLIGENCE = 2;
        public const int ENGINEERING = 3;
        public const int BACK_TO_LECTURETABLEMENU = 4;

        // 관심과목 담기 메뉴 
        public const int ADD = 1;
        public const int INQUIRY = 2;
        public const int BACK = 3;

        // 수강 신청 메뉴 
        public const int ATTENTIONREGISTER = 1;
        public const int REGISTER_BACK = 4; 

        // 시간이 겹치는 지 판단
        public const int ONETIME = 8;
        public const int TWOTIME = 16;
        public const bool DAY_NOFIND = false;
        public const bool DAY_FIND = true;
        public const bool DO_REGISTER = true;
        public const bool NO_REGISTER = false;


    }
}
