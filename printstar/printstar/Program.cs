using System;

namespace printstar
{
    class Program
    {
        class Bigger // 가운데 별 찍기 
        {
            public void PrintingBigger(int line) // 별 찍기 함수 
            {

                for (int i = 1; i < line + 1; i++)
                {
                    for (int k = line; k > i; k--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < (2 * i - 1); j++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
            }
        }

        class Smaller // 가운데 별 찍기 반대로 찍기
        {

            public void PrintingSmaller(int line) // 반대로 찍기 함수 
            {
                for (int i = 1; i < line + 1; i++)
                {
                    for (int k = 1; k < i; k++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 2 * line; j > (2 * i - 1); j--)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
            }
        }

        class Diamond // 다이아몬드 찍기 클래스
        {
            public void PrintingDiamond(int line)
            {
                for (int i = 1; i < line + 1; i++) // 다이아몬드 윗 부분 
                {
                    for (int k = line; k > i; k--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < (2 * i - 1); j++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }

                for (int x = 1; x < line; x++) // 다이아몬드 아랫부분
                {
                    for (int y = 0; y < x; y++)
                    {
                        Console.Write(" ");
                    }
                    for (int z = (line - 1) * 2; z > (2 * x - 1); z--)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }

            }

        }
        static int AskType() // 무슨 모양으로 출력하고 싶은지 물어보는 함수 
        {
            int type;
            Console.WriteLine("1.가운데 정렬 별 찍기\n");
            Console.WriteLine("2.1번 반대로 찍기\n");
            Console.WriteLine("3.모래 시계 찍기\n");
            Console.WriteLine("4.다이아 찍기");
            type = Convert.ToInt32(Console.ReadLine());
            return type; 
        }

        static int AskLine() // 몇 줄 출력하고 싶은 물어보는 함수 
        {
            int line; 
            Console.WriteLine("몇 줄 만들고 싶으세요? : ");
            line = Convert.ToInt32(Console.ReadLine());
            return line;
        }

        static void PrintingStar(int type,int line) // 별 출력 함수
        {
            Bigger bigger = new Bigger();
            Smaller smaller = new Smaller();
            Diamond diamond = new Diamond();
            switch (type)
            {

                case 1: // 가운데 정렬 찍기일 때 
                    bigger.PrintingBigger(line);
                    break;

                case 2: // 1번 반대로 찍기 일 때 
                    smaller.PrintingSmaller(line);
                    break;

                case 3: // 모래시계 찍기
                    smaller.PrintingSmaller(line);
                    bigger.PrintingBigger(line);
                    break;
                case 4: // 다이아몬드 찍기
                    diamond.PrintingDiamond(line);
                    break;

            }
        }
    
        
        class PrintStar
        {

            static void Main(string[] args)
            {
                int type; // 어떤 모양으로 출력할 지 결정할 변수
                int line; // 몇 줄을 출력할 지 결정할 변수
                int again = 1; // 끝낼 건지 아닌 지 결정할 변수 
             
                while (again != 2) {
                    type = AskType();
                    line = AskLine();
                    PrintingStar(type, line);
                    Console.WriteLine("다시시작 : 1 종료 : 2");
                    again = int.Parse(Console.ReadLine()); 
                } 
                


            }
        }

        
        
    }
}
