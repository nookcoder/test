using System;

namespace printstar
{
    class Program
    {
        class Bigger // 가운데 별 찍기 
        {
            public void printingBigger(int line) // 별 찍기 함수 
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

            public void printingSmaller(int line) // 반대로 찍기 함수 
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
            public void printingDiamond(int line)
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
        static int askType() // 무슨 모양으로 출력하고 싶은지 물어보는 함수 
        {
            int type; 
            string numberCheck; // 1~4 사이 숫자인지 아닌 지 판단할 때 쓰일 변수  

            Console.WriteLine("1.가운데 정렬 별 찍기\n");
            Console.WriteLine("2.1번 반대로 찍기\n");
            Console.WriteLine("3.모래 시계 찍기\n");
            Console.WriteLine("4.다이아 찍기");

            numberCheck = Console.ReadLine();

            bool istype = int.TryParse(numberCheck, out type); // 1~4 숫자가 맞는 지 판단 

            if (!istype || type <= 0 || type > 4) // 1~4 사이 정수만 입력받게 하기 
            {

                while (!istype || type <= 0 || type > 4)
                {
                    Console.WriteLine("1~4사이 정수만 입력해주세요! ");
                    numberCheck = Console.ReadLine();
                    istype = int.TryParse(numberCheck, out type);
                }

                return type;
            }

            else
            {

                return type; 

            }


        }

        static int askLine() // 몇 줄 출력하고 싶은 물어보는 함수 
        {
            int line;
            string numberCheck; // 양의 정수가 입력됐는지 확인할 변수

            Console.WriteLine("몇 줄 만들고 싶으세요? : ");

            numberCheck = Console.ReadLine(); // 줄 수 입력받기

            bool isline = int.TryParse(numberCheck, out line);

            if (!isline || line <= 0) // 양의 정수만 입력 받기 
            {

                while (!isline || line <= 0) // 양의 정수가 아닐 때 반복 실행하기
                {
                    Console.WriteLine("양의 정수만 입력해주세요! ");
                    numberCheck = Console.ReadLine();
                    isline = int.TryParse(numberCheck, out line);
                }

                return line;
            }

            else
            {
                return line;
            }
        }
        

        static void printingStar(int type,int line) // 별 출력 함수
        {

            Bigger bigger = new Bigger();
            Smaller smaller = new Smaller();
            Diamond diamond = new Diamond();

            switch (type)
            {

                case 1: // 가운데 정렬 찍기일 때 
                    bigger.printingBigger(line);
                    break;

                case 2: // 1번 반대로 찍기 일 때 
                    smaller.printingSmaller(line);
                    break;

                case 3: // 모래시계 찍기
                    smaller.printingSmaller(line);
                    bigger.printingBigger(line);
                    break;

                case 4: // 다이아몬드 찍기
                    diamond.printingDiamond(line);
                    break;

            }
        }
        
        static int replay() // 다시시작 할 것인지, 종료할 것인지 선택하는 함수 
        {
            int again ; // 다시 시작, 종료 선택 변수 
            string numberCheck; // 1,2 가 입력 됐는 지 확인할 변수

            Console.WriteLine("다시시작 : 1 종료 : 2");

            numberCheck = Console.ReadLine(); 

            bool isagain = int.TryParse(numberCheck, out again); // 원하는 숫자가 입력 됐는 지 확인

            if(!isagain || again != 1 || again != 2)
            {

                while(!isagain || (again != 1 && again != 2)) // 문자이거나 1또는 2가 아닌 숫자가 입력됐을 때 다시 실행 
                {
                    Console.WriteLine("1(다시시작) 또는 2(종료) 만 입력해주세요");
                    numberCheck = Console.ReadLine();
                    isagain = int.TryParse(numberCheck, out again);
                }

                return again; 
            }
            else
            {
                return again;
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
                    type = askType(); 
                    line = askLine(); 
                    printingStar(type, line);
                    again = replay(); 
                } 
                


            }
        }

        
        
    }
}
