using System;

namespace printstar
{
    class Program
    {
        class Bigger
        {
            public int Line; 
            public void PrintingBigger()
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
