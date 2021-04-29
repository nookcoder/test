using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LectureTimeTable2.VOs;

namespace LectureTimeTable2.Registration
{
    class JugementOfOverlapedTime
    {
        private string existingDay; // 수강신청이 되어있는 강의의 요일 
        private string lastestDay;  // 수강신청할 강의의 요일. 
        private string existingTimeString; // 수강 신청이 되어있는 강의의 시간 문자열
        private string lastestTimeString;  // 수강 신청할 강의의 시간 문자열 

        public JugementOfOverlapedTime()
        {
            
        }

        // 검색해서 수강 신청 시 기존 수강신청 과목과 비교 
        public void JugementOverLa(List<RegistrationVO> registrations,List<CourseVO> courses)
        {
            while(true)
            {
                for(int indexOfRegistrations = 0; indexOfRegistrations < registrations.Count; indexOfRegistrations++)
                {
                    // 수강 신청되어 있는 강좌의 요일과 시간문자열을 순서대로 가져옴. 
                    existingDay = Regex.Replace(registrations[indexOfRegistrations].CourseTime, @"[^가-힣]", "");
                    existingTimeString = Regex.Replace(registrations[indexOfRegistrations].CourseTime, @"[^0-9]", "");

                    // 수강 신청할 강의의 요일과 시간문자열을 가져옴 
                    for(int indexOfCourse = 0; indexOfCourse < 169; indexOfCourse++)
                    {
                        lastestDay = Regex.Replace(courses[indexOfCourse].CourseTime, @"[^가-힣]", "");
                        lastestTimeString = Regex.Replace(courses[indexOfCourse].CourseTime, @"[^0-9]", "");
                        if(existingTimeString.Length == Constants.ONETIME && lastestTimeString.Length == Constants.ONETIME)
                        {

                        }
                        else if (existingTimeString.Length == Constants.ONETIME && lastestTimeString.Length == Constants.TWOTIME)
                        {

                        }
                        else if (existingTimeString.Length == Constants.TWOTIME && lastestTimeString.Length == Constants.ONETIME)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }
}
