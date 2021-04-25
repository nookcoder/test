using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LectureTimeTable2.LectureProperty
{
    class LectureException:LectureScreen
    {
        // 강의 검색 방법 선택 메뉴창에서 예외처리 
        public string HandleLectureTimeTableMenuInput(string menuCheck)
        {
            while (Constants.ERROR)
            {
                if (Regex.IsMatch(menuCheck, @"^[1-6]$"))
                {
                    break;
                }

                PrintLectureTimeTableMenu();
                PrintMenuError();
                menuCheck = Console.ReadLine();
            }

            return menuCheck;
        }

        // 전공으로 검색에서 나오는 메뉴 예외처리 
        public string HandleSearchByMajor(string menuCheck)
        {
            while (Constants.ERROR)
            {
                if (Regex.IsMatch(menuCheck, @"^[1-4]$"))
                {
                    break;
                }

                PrintLectureTimeTableMenu();
                PrintMenuError();
                menuCheck = Console.ReadLine();
            }

            return menuCheck;
        }
    }
}
