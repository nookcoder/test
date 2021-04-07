using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks; 

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
        Console.WriteLine(" 다음으로 넘어가려면 엔터를 눌러주세요.");
        Console.WriteLine("\n");
        Console.ReadKey();
    }

    public void DetermineStartOrNot(int StartOrNot)
    {
        if (StartOrNot == 2)
        {
            Environment.Exit(0);
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
        Console.WriteLine("  ------------------------------------ ");
        startOrNot = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        return startOrNot;
     }

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
     }
 }
    
class Play
{
    public char[] arraryUserMark =
    {
        '1','2','3','4','5','6','7','8','9'
    };
    public void PaintBoard()
    {
        Console.WriteLine(" ------------------------------------ ");
        Console.WriteLine(" |          |            |           |");
        Console.WriteLine(" |     {0}     |      {1}      |     {2}      |",arraryUserMark[0], arraryUserMark[1], arraryUserMark[2]);
        Console.WriteLine(" |          |            |           |");
        Console.WriteLine(" ------------------------------------ ");
        Console.WriteLine(" |          |            |           |");
        Console.WriteLine(" |     {0}     |      {1}      |     {2}      |", arraryUserMark[3], arraryUserMark[4], arraryUserMark[5]);
        Console.WriteLine(" |          |            |           |");
        Console.WriteLine(" ------------------------------------ ");
        Console.WriteLine(" |          |            |           |");
        Console.WriteLine(" |     {0}     |      {1}      |     {2}      |", arraryUserMark[6], arraryUserMark[7], arraryUserMark[8]);
        Console.WriteLine(" |          |            |           |");
        Console.WriteLine(" ------------------------------------ ");
    }
}



      