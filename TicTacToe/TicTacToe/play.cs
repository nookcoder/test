using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Play
    {
        public bool decidVictory = false; // 승패가 결정나면 True 로 변경 
        public const int firstTurn = 1;
        public const int secondTurn = 2;
        public char playerMark;
        public int countTurn = 0;
        public int player = secondTurn; // 변수 초기화 
        public int point; // 말의 위치 
        public static char[] arraryMark =
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

        public void PlayGameWithUser()
        { 
            do // 플레이어가 번갈아가면서 말을 둔다. 
            {
                if (player == secondTurn)
                {
                    player = firstTurn;
                    Console.WriteLine(" 원하는 위치의 숫자를 입력해주세요");
                    point = Convert.ToInt32(Console.ReadLine());
                    PutMark(player, point);
                }

                else if (player == firstTurn)
                {
                    player = secondTurn;
                    Console.WriteLine(" 원하는 위치의 숫자를 입력해주세요");
                    point = Convert.ToInt32(Console.ReadLine());
                    PutMark(player, point);
                }

                countTurn++;
                Console.Clear();
                PaintBoard();
                JudgeHoriziontal();
                JudgeVertical();
                JudgeDiagnal();

            } while (countTurn < 9 && !decidVictory);

            if(countTurn == 9)
            {
                Console.Clear(); 
                Console.WriteLine("    ===================================== ");
                Console.WriteLine("   |                                     | ");
                Console.WriteLine("   |            무   승   부             |");
                Console.WriteLine("   |                                     | ");
                Console.WriteLine("    ===================================== ");
            }
        }    
        public void PlayGameWithComputer()
        {
            Random random = new Random();  


            do // 플레이어가 번갈아가면서 말을 둔다. 
            {
                if (player == secondTurn)
                {
                    player = firstTurn;
                    Console.WriteLine(" 원하는 위치의 숫자를 입력해주세요");
                    point = Convert.ToInt32(Console.ReadLine());
                    PutMark(player, point);
                }

                else if (player == firstTurn)
                {
                    player = secondTurn;
                    point = random.Next(1, 10); 
                    PutMark(player, point);
                }

                countTurn++;
                Console.Clear();
                PaintBoard();
                JudgeHoriziontal();
                JudgeVertical();
                JudgeDiagnal();

                } while (countTurn < 9 && !decidVictory);

                if (countTurn == 9)
                {
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |            무   승   부             |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                }
        }
        

        public void PutMark(int player, int point) // player Board 에서 번호를 선택했을 때 숫자가 player의 말로 바뀌는 함수
        {

            if (player == firstTurn)
            {
                playerMark = 'X'; 
            }

            else if (player == secondTurn)
            {
                playerMark = 'O';
            }

            switch (point)
            {
                case 1: arraryMark[0] = playerMark; break;
                case 2: arraryMark[1] = playerMark; break;
                case 3: arraryMark[2] = playerMark; break;
                case 4: arraryMark[3] = playerMark; break;
                case 5: arraryMark[4] = playerMark; break;
                case 6: arraryMark[5] = playerMark; break;
                case 7: arraryMark[6] = playerMark; break;
                case 8: arraryMark[7] = playerMark; break;
                case 9: arraryMark[8] = playerMark; break;
            }

        }
        public void JudgeHoriziontal()
        {
        if (arraryMark[0] == playerMark && arraryMark[1] == playerMark && arraryMark[2] == playerMark
                || arraryMark[3] == playerMark && arraryMark[4] == playerMark && arraryMark[5] == playerMark
                || arraryMark[6] == playerMark && arraryMark[7] == playerMark && arraryMark[8] == playerMark)
            {
                if(playerMark == 'X')
                {
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |   1번 플레이어 님이 승리하셨습니다  |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                    decidVictory = true;
                }
                else if(playerMark == 'O')
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |   2번 플레이어 님이 승리하셨습니다  |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                    decidVictory = true;
                }
            }
        } // 가로로 빙고가 됐는지 판단
        
        public void JudgeVertical()
        {
            if (arraryMark[0] == playerMark && arraryMark[3] == playerMark && arraryMark[6] == playerMark
                    || arraryMark[1] == playerMark && arraryMark[4] == playerMark && arraryMark[7] == playerMark
                    || arraryMark[2] == playerMark && arraryMark[5] == playerMark && arraryMark[8] == playerMark)
            {
                if (playerMark == 'X')
                {
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |   1번 플레이어 님이 승리하셨습니다  |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                    decidVictory = true;
                }
                else if (playerMark == 'O')
                {
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |   2번 플레이어 님이 승리하셨습니다  |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                    decidVictory = true;
                }
            }
        }  // 세로로 빙고가 됐는지 판단

        public void JudgeDiagnal()
        {
            if (arraryMark[0] == playerMark && arraryMark[4] == playerMark && arraryMark[8] == playerMark
                    || arraryMark[2] == playerMark && arraryMark[4] == playerMark && arraryMark[6] == playerMark)
            {
                if (playerMark == 'X')
                {
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |   1번 플레이어 님이 승리하셨습니다  |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                    decidVictory = true;
                }
                else if (playerMark == 'O')
                {
                    Console.Clear();
                    Console.WriteLine("    ===================================== ");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("   |   2번 플레이어 님이 승리하셨습니다  |");
                    Console.WriteLine("   |                                     | ");
                    Console.WriteLine("    ===================================== ");
                    decidVictory = true;
                }
            }
        } // 대각선으로 빙고가 됐는지 판단
    }   
}


