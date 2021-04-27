using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.VOs
{
    class AttentionVO
    {
        private string major;
        private string courseNumber;
        private string distribution;
        private string title;
        private string sortation;
        private string grade;
        private int score;
        private string courseTime;
        private string classRoom;
        private string professor;
        private string language;

        public AttentionVO(object major, object courseNumber, object distribution, object title, object sortation,
                         object grade, object score, object courseTime, object classRoom, object professor, object language)
        {
            this.major = major.ToString();
            this.courseNumber = courseNumber.ToString();
            this.distribution = distribution.ToString();
            this.title = title.ToString();
            this.sortation = sortation.ToString();
            this.grade = grade.ToString();
            this.score = Convert.ToInt32(score);
            this.courseTime = courseTime.ToString();
            this.classRoom = Convert.ToString(classRoom);
            this.professor = Convert.ToString(professor);
            this.language = language.ToString();
        }

        public string Major
        {
            get { return major; }
            set { major = value; }
        }

        public string CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value; }
        }

        public string Distribution
        {
            get { return distribution; }
            set { distribution = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Sortation
        {
            get { return sortation; }
            set { sortation = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string CourseTime
        {
            get { return courseTime; }
            set { courseTime = value; }
        }

        public string ClassRoom
        {
            get { return classRoom; }
            set { classRoom = value; }
        }

        public string Professor
        {
            get { return professor; }
            set { professor = value; }
        }
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
    }
}
