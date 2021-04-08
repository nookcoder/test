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
            Console.WriteLine(" 다음으로 넘어가려면 아무키나 눌러주세요 눌러주세요.");
            Console.ReadKey();
            Console.WriteLine("\n");
            Console.Clear();
        }

        public int DetermineStartOrNot(int StartOrNot)
        {
   
            if(StartOrNot == 1)
            {
                return 1; 
            }

            else if (StartOrNot == 2)
            {
                Environment.Exit(0);
                return 2; 
            }

            else
            {
                Introduction();
                return 3; 
            }

        }
    }
    public class Ask
    {
        public int AskWantStart()
        {
            int startOrNot;

            Console.WriteLine("  ------------------------------------ ");
            Console.WriteLine(" |           1. 시작하기              |");
            Console.WriteLine(" |           2. 종료하기              |");
            Console.WriteLine(" |           3. 뒤로가기              |");
            Console.WriteLine("  ------------------------------------ ");
            startOrNot = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            return startOrNot;
        } // 시작할 것인지 종료 할 것인지 물어보기(시작이면 1, 종료면 2를 반환)

        public int AskType()
        {
            int gameType;

            Console.WriteLine("  ------------------------------------ ");
            Console.WriteLine(" |           1. vs Computer           |");
            Console.WriteLine(" |           2. vs User               |");
            Console.WriteLine(" |           3. ScoreBoard            |");
            Console.WriteLine("  ------------------------------------ ");
            gameType = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return gameType;
        } // 유저가 하고 싶은 게임 종류 선택하기 
    }

}

