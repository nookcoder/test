using System;

namespace printstar
{
    class Program
    {
        class Bigger // 가운데 별 찍기 
        {
            public int Line; // 입력 받은 줄 수
            public void PrintingBigger() // 별 찍기 함수 
            {
                
                for(int i = 1; i < Line + 1; i++)
                {
                    for(int k = Line; k > i; k-- )
                    {
                        Console.Write(" "); 
                    }
                    for(int j = 0; j < (2*i - 1); j++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
            }
        }
        class MainApp
        {

            static void Main(string[] args)
            {
             
            }
        }

        
        
    }
}
