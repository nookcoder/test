using System;

 public class Start
 {
    private int start = 1;
    private int end = 2; 
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

 }

      