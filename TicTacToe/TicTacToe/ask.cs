using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Ask
    {
        public string AskWantStart()
        {
            string startOrNot; 

            Console.WriteLine("    ------------------------------------ ");
            Console.WriteLine("   |           1. 시작하기              |");
            Console.WriteLine("   |           2. 종료하기              |");
            Console.WriteLine("   |           3. 뒤로가기              |");
            Console.WriteLine("    ------------------------------------ ");

            startOrNot = Console.ReadLine();
            
            Console.Clear();

            return startOrNot;
        } // 시작할 것인지 종료 할 것인지 물어보기(시작이면 1, 종료면 2를 반환, 다시하기면 3을 반환)

        public string AskType()
        {
            string gameType;

            Console.WriteLine("  ------------------------------------ ");
            Console.WriteLine(" |           1. vs Computer           |");
            Console.WriteLine(" |           2. vs User               |");
            Console.WriteLine(" |           3. ScoreBoard            |");
            Console.WriteLine("  ------------------------------------ ");
            
            gameType = Console.ReadLine();
            
            Console.Clear();
            
            return gameType;
        } // 유저가 하고 싶은 게임 종류 선택하기 

        public string AskReplay()
        {
            string replayOrNot;
             
            Console.WriteLine("    ------------------------------------ ");
            Console.WriteLine("   |           1. 다시하기              |");
            Console.WriteLine("   |           2. 종료하기              |");
            Console.WriteLine("    ------------------------------------ ");

            replayOrNot = Console.ReadLine();
            
            Console.Clear();

            return replayOrNot;
        }
    }
}
