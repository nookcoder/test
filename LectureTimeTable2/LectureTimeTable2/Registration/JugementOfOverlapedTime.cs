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
        public bool IsRegister(List<RegistrationVO> registrations, string courseTime)
        {
            bool isFound = Constants.DAY_NOFIND;
            bool isRegister = Constants.DO_REGISTER;

            for (int indexOfRegistrations = 0; indexOfRegistrations < registrations?.Count; indexOfRegistrations++)
            {
                // 수강 신청되어 있는 강좌의 요일과 시간문자열을 순서대로 가져옴. 
                existingDay = Regex.Replace(registrations[indexOfRegistrations].CourseTime, @"[^가-힣]", "");
                existingTimeString = Regex.Replace(registrations[indexOfRegistrations].CourseTime, @"[^0-9]", "");

                // 수강 신청할 강의의 요일과 시간문자열을 가져옴 
                lastestDay = Regex.Replace(courseTime, @"[^가-힣]", "");
                lastestTimeString = Regex.Replace(courseTime, @"[^0-9]", "");

                if (existingTimeString.Length == Constants.ONETIME && lastestTimeString.Length == Constants.ONETIME)
                {
                    isFound = IsHaveDay(existingDay, lastestDay);

                    if (isFound)
                    {
                        isRegister = IsRegisterWithOneOne(existingTimeString, lastestTimeString);
                    }

                    else
                    {
                        isRegister = Constants.DO_REGISTER;
                    }

                }

                else if (existingTimeString.Length == Constants.ONETIME && lastestTimeString.Length == Constants.TWOTIME)
                {
                    isFound = IsHaveDay(existingDay, lastestDay);

                    if (isFound)
                    {
                        isRegister = IsRegisterWithOneTwo(lastestTimeString, existingTimeString);
                    }

                    else
                    {
                        isRegister = Constants.DO_REGISTER;
                    }
                }

                else if (existingTimeString.Length == Constants.TWOTIME && lastestTimeString.Length == Constants.ONETIME)
                {
                    isFound = IsHaveDay(existingDay, lastestDay);

                    if (isFound)
                    {
                        isRegister = IsRegisterWithOneTwo(existingTimeString, lastestTimeString);
                    }

                    else
                    {
                        isRegister = Constants.DO_REGISTER;
                    }
                }
            }

            return isRegister;
        }

        //  겹치는 요일이 있는 지 확인 
        public bool IsHaveDay(string existingDay, string lastestDay)
        {
            bool isFindDay = Constants.DAY_NOFIND;
            for (int index = 0; index < lastestDay.Length; index++)
            {
                if (existingDay.Contains(lastestDay[index]))
                {
                    isFindDay = Constants.DAY_FIND;
                }
            }

            return isFindDay;
        }

        public bool IsRegisterWithOneOne(string existingTimeString, string lastestTimeString)
        {
            bool isRegister = Constants.DO_REGISTER;

            // 수강 신청이 된 강의와 수강신청을 할 강의의 시간을 다룰 변수
            int exstingTime = Convert.ToInt32(existingTimeString);
            int lastestTime = Convert.ToInt32(lastestTimeString); ;

            // 시작시간과 끝나는 시간 구하기 
            int exstingStartTime = exstingTime / 10000;
            int exstingEndTime = exstingTime % 10000;
            int lastestStartTime = lastestTime / 10000;
            int lastestEndTime = lastestTime % 10000;

            if ((exstingStartTime <= lastestStartTime && lastestStartTime <= exstingEndTime) ||
                (exstingStartTime <= lastestEndTime && lastestEndTime <= exstingEndTime))
            {
                isRegister = Constants.NO_REGISTER;
            }

            return isRegister;
        }

        // 시간 한개와 시간 두개 일 때 
        public bool IsRegisterWithOneTwo(string existingTimeString, string lastestTimeString)
        {
            bool isRegister = Constants.DO_REGISTER;

            // 시간 정보가 두 개일 때 두개로 나눠서 저장 
            string existingTimeStringFirst = existingTimeString.Substring(0, 8);
            string existingTimeStringSecond = existingTimeString.Substring(8, 8);

            // 수강 신청이 된 강의와 수강신청을 할 강의의 시간을 다룰 변수
            int exstingTimeFirst = Convert.ToInt32(existingTimeStringFirst);
            int exstingTimeSecond = Convert.ToInt32(existingTimeStringSecond);
            int lastestTime = Convert.ToInt32(lastestTimeString);

            // 시작시간과 끝나는 시간 구하기 
            int exstingStartTimeFirst = exstingTimeFirst / 10000;
            int exstingEndTimeFirst = exstingTimeFirst % 10000;
            int exstingStartTimeSecond = exstingTimeSecond / 10000;
            int exstingEndTimeSecond = exstingTimeSecond % 10000;
            int lastestStartTime = lastestTime / 10000;
            int lastestEndTime = lastestTime % 10000;

            if (exstingTimeFirst < exstingTimeSecond)
            {
                if((lastestStartTime <= exstingEndTimeFirst && exstingStartTimeSecond <= lastestEndTime) ||
                    (lastestStartTime <= exstingStartTimeFirst && exstingStartTimeFirst <= lastestEndTime) || 
                    (exstingStartTimeSecond <= lastestStartTime && lastestStartTime <= exstingEndTimeSecond))
                {
                    isRegister = Constants.NO_REGISTER; ;
                }
            }

            else if(exstingTimeFirst >= exstingTimeSecond )
            {
                if ((lastestStartTime <= exstingEndTimeSecond && exstingStartTimeFirst <= lastestEndTime) ||
                    (lastestStartTime <= exstingStartTimeSecond && exstingStartTimeSecond <= lastestEndTime) ||
                    (exstingStartTimeFirst <= lastestStartTime && lastestStartTime <= exstingEndTimeFirst))
                {
                    isRegister = Constants.NO_REGISTER; ;
                }
            }

            return isRegister;
        }

        // 시간 한개와 시간 두개 일 때 
        public bool IsRegisterWithTwoTwo(string existingTimeString, string lastestTimeString)
        {
            bool isRegister = Constants.DO_REGISTER;

            // 시간 정보가 두 개일 때 두개로 나눠서 저장 
            string existingTimeStringFirst = existingTimeString.Substring(0, 8);
            string existingTimeStringSecond = existingTimeString.Substring(8, 8);
            string lastestTimeStringFirst = lastestTimeString.Substring(0, 8);
            string lastestTimeStringSecond = lastestTimeString.Substring(8, 8);

            // 수강 신청이 된 강의와 수강신청을 할 강의의 시간을 다룰 변수
            int exstingTimeFirst = Convert.ToInt32(existingTimeStringFirst);
            int exstingTimeSecond = Convert.ToInt32(existingTimeStringSecond);
            int lastestTimeFirst = Convert.ToInt32(lastestTimeStringFirst);
            int lastestTimeSecond = Convert.ToInt32(lastestTimeStringSecond);


            // 시작시간과 끝나는 시간 구하기 
            int exstingStartTimeFirst = exstingTimeFirst / 10000;
            int exstingEndTimeFirst = exstingTimeFirst % 10000;
            int exstingStartTimeSecond = exstingTimeSecond / 10000;
            int exstingEndTimeSecond = exstingTimeSecond % 10000;

            int lastestStartTimeFirst = lastestTimeFirst / 10000;
            int lastestEndTimeFirst = lastestTimeFirst % 10000;
            int lastestStartTimeSecond = lastestTimeSecond / 10000;
            int lastestEndTimeSecond = lastestTimeSecond % 10000;

            // 수강 신청 되어있는 두 강의가 모두 먼저 시작 할때 
            if ((exstingStartTimeFirst <= lastestStartTimeFirst && exstingStartTimeFirst <= lastestStartTimeSecond) && (exstingStartTimeSecond <= lastestStartTimeFirst && exstingStartTimeSecond <= lastestStartTimeSecond))
            {
                if (exstingEndTimeFirst <= lastestStartTimeFirst && exstingEndTimeFirst <= lastestStartTimeSecond && exstingEndTimeSecond <= lastestStartTimeFirst && exstingEndTimeSecond <= lastestStartTimeSecond)
                {
                    isRegister = Constants.DO_REGISTER;
                }
            }

            else if ((exstingStartTimeFirst >= lastestStartTimeFirst && exstingStartTimeFirst >= lastestStartTimeSecond) && (exstingStartTimeSecond >= lastestStartTimeFirst && exstingStartTimeSecond >= lastestStartTimeSecond))
            {
                if (exstingStartTimeFirst >= lastestEndTimeFirst && exstingStartTimeFirst >= lastestEndTimeSecond && exstingStartTimeSecond >= lastestEndTimeFirst && exstingStartTimeSecond >= lastestEndTimeSecond)
                {
                    isRegister = Constants.DO_REGISTER;
                }
            }

            else if ((lastestEndTimeFirst <= exstingStartTimeFirst && lastestEndTimeFirst <= exstingStartTimeSecond && lastestStartTimeSecond >= exstingEndTimeSecond && lastestStartTimeSecond >= exstingEndTimeFirst) ||
                    (lastestEndTimeSecond <= exstingStartTimeFirst && lastestEndTimeSecond <= exstingStartTimeSecond && lastestStartTimeFirst >= exstingEndTimeSecond && lastestStartTimeFirst >= exstingEndTimeFirst))
            {
                isRegister = Constants.DO_REGISTER;
            }

            return isRegister;
        }
    }
}
