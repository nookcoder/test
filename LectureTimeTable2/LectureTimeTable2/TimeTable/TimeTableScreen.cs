using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable2.TimeTable
{
    class TimeTableScreen
    {
        // 표 모양 출력 
        public void PrintTimeTable()
        {
            Console.SetWindowSize(120, 45);
            int hour1 = 10;
            int hour2 = 11;
            String s = String.Format("{0,-25}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}\n\n", " ", "월", "화", "수", "목", "금");
            s += new string('-', Console.BufferWidth);
            Console.WriteLine($"\n{s}");
            Console.WriteLine($" 09:00 ~ 09:30 |");
            Console.WriteLine($"               |");
            Console.WriteLine($" 09:30 ~ 10:00 |");
            Console.WriteLine($"               |");
            for (int time = 0; time <= 9; time++)
            {
                Console.WriteLine($" {hour1 + time}:00 ~ {hour1 + time}:30 |");
                Console.WriteLine($"               |");
                Console.WriteLine($" {hour1 + time}:30 ~ {hour2 + time}:00 |");
                Console.WriteLine($"               |");
            }
        }
    }
}
