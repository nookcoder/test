using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.VOs
{
    class CoursesVO
    {
        private int number;
        private string major;
        private int lectureNumber;
        private int distribution;
        private string title;
        private string sortation;
        private int schoolYear;
        private int score;
        private string day;
        private string lectureTime;
        private string clasRoom;
        private string professor;
        private string language;
    
        public CoursesVO(int number, string major, int lectureNumber, int distribution, string title, string sortation,
                         int schoolYear, int score, string day, string lectureTime, string clasRoom, string professor, string language)
        {
            this.number = number;
            this.major = major;
            this.lectureNumber = lectureNumber;
            this.distribution = distribution;
            this.title = title;
            this.sortation = sortation;
            this.schoolYear = schoolYear;
            this.score = score;
            this.day = day;
            this.lectureTime = lectureTime;
            this.clasRoom = clasRoom;
            this.professor = professor;
            this.language = language;
        }
    }
}
