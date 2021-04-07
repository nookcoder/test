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
    
class Play
{
    public char[] arraryMark =
    {
        '1','2','3','4','5','6','7','8','9'
    }; // 플레이어가 말을 놓을 부분
    public void PaintBoard()
    {
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arraryMark[0], arraryMark[1], arraryMark[2]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arraryMark[3], arraryMark[4], arraryMark[5]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", arraryMark[6], arraryMark[7], arraryMark[8]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
    } //게임보드 그리기 

    
    public void ChangeTrun()
    {
        const int firstTurn = 1;
        const int secondTurn = 2;
        int countTurn = 0; 
        int player = secondTurn;

        do
        {
            if (player == secondTurn)
            {
                player = firstTurn;
                //PutMark( player, input)
            }

            else if (player == firstTurn)
            {
                player = secondTurn;
                //PutMark( player, input) 
            }

            countTurn++;
            PaintBoard();

        } while (countTurn < 10);
    }

    public void PutMark(int player, int input)
    {

    }
}



      