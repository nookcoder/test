using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Start
    {
        public void Introduction()
        {
            Console.WriteLine("          -----------------             ");
            Console.WriteLine("          |  TIc Tac Toe  |             ");
            Console.WriteLine("          -----------------             ");
            Console.WriteLine("\n");
            Console.WriteLine(" ------------ 게임 설명 ----------------");
            Console.WriteLine("\n");
            Console.WriteLine(" 1. 3 X 3 9개의 칸 안에 두 사람이 번갈아");
            Console.WriteLine("    가면서 돌을 두는 3목 게임");
            Console.WriteLine(" 2. 연달아 3개의 O나 X를 먼저 그리는 사람이");
            Console.WriteLine("    이긴다. ");
            Console.WriteLine("\n");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine(" 다음으로 넘어가려면 아무키나 눌러주세요.");
            Console.ReadKey();
            Console.WriteLine("\n");
            Console.Clear();
        }

        public void DetermineStartOrNot(int StartOrNot) // 게임 처음 시작 시 뒤로가기를 포함한 시작/종료 기능  
        {
   
            if(StartOrNot == 1)
            {
            }

            else if (StartOrNot == 2)
            {
                Environment.Exit(0);
            }

            else
            {
                Introduction();
            }

        }
    }
}

