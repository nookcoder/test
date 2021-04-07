using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Play
    {
        Random random = new Random(); // 컴퓨터가 놓는 말을 위해 Random class 호출 

        public bool correctPoint; // 이미 놓은 위치에 다시 놓았는 지 확인하는 값
        public bool decidVictory = false; // 승패가 결정나면 True 로 변경 

        public const int firstTurn = 1;
        public const int secondTurn = 2;
        public int player = secondTurn; // 변수 초기화 
        
        public char playerMark; // player1 은 X , player2 는 O 로 표시 
        public int point; // 말의 위치 

        public int countTurn = 0; // 턴 수 9번이 넘어가면 무승부         

        public int winByVertical;
        public int winByHoriziontal;
        public int winByDiagnal;

        public int winWho; 

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

        public int PlayGameWithUser()
        { 
            do // 플레이어가 번갈아가면서 말을 둔다. 
            {
                if (player == secondTurn)
                {
                    player = firstTurn;
                    Console.WriteLine(" 원하는 위치의 숫자를 입력해주세요");
                    point = Convert.ToInt32(Console.ReadLine());
                    PutMarkByUser(player, point);
                }

                else if (player == firstTurn)
                {
                    player = secondTurn;
                    Console.WriteLine(" 원하는 위치의 숫자를 입력해주세요");
                    point = Convert.ToInt32(Console.ReadLine());
                    PutMarkByUser(player, point);
                }

                countTurn++;
                Console.Clear();
                PaintBoard();
                winByHoriziontal = JudgeHoriziontal();
                winByVertical = JudgeVertical();
                winByDiagnal = JudgeDiagnal();

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

            winWho = winByHoriziontal + winByVertical + winByDiagnal; // 승패가 결정났을 경우 승자가 누군지 결정 

            return winWho;

        }    
        public int PlayGameWithComputer()
        {

            do // 플레이어가 두면 컴퓨터는 랜덤하게 말을 둔다. . 
            {
                if (player == secondTurn)
                {
                    player = firstTurn;
                    Console.WriteLine(" 원하는 위치의 숫자를 입력해주세요");
                    point = Convert.ToInt32(Console.ReadLine());
                    PutMarkByUser(player, point);
                }

                else if (player == firstTurn)
                {
                    player = secondTurn;
                    point = random.Next(1, 10);
                    PutMarkByComputer(player, point);
                }

                countTurn++;
                Console.Clear();
                PaintBoard();
                winByHoriziontal = JudgeHoriziontal();
                winByVertical = JudgeVertical();
                winByDiagnal = JudgeDiagnal();

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

            winWho = winByHoriziontal + winByVertical + winByDiagnal; // 승패가 결정났을 경우 승자가 누군지 결정 

            return winWho; 
        }


        public void PutMarkByUser(int player, int point) // User 가 놓는 말에 대한 함수 
        {

            if (player == firstTurn)
            {
                playerMark = 'X'; 
            }

            else if (player == secondTurn)
            {
                playerMark = 'O';
            }
            do  // 픞레이어가 같은 자리에 뒀는지 확인
            {

                if ((point == 1) && (arraryMark[0] == '1') ||
                    (point == 2) && (arraryMark[1] == '2') ||
                    (point == 3) && (arraryMark[2] == '3') ||
                    (point == 4) && (arraryMark[3] == '4') ||
                    (point == 5) && (arraryMark[4] == '5') ||
                    (point == 6) && (arraryMark[5] == '6') ||
                    (point == 7) && (arraryMark[6] == '7') ||
                    (point == 8) && (arraryMark[7] == '8') ||
                    (point == 9) && (arraryMark[8] == '9'))
                {
                    switch (point) // 해당 자리에 player 말을 놓는다. 
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

                    correctPoint = true; // do while 문 종료 

                }

                else // 말이 있는 자리에 두었을 때. 
                {
                    Console.WriteLine(" 이미 둔 자리입니다. 다시 선택해주세요! ");
                    point = Convert.ToInt32(Console.ReadLine());
                    correctPoint = false;
                    Console.Clear();
                }

            } while (!correctPoint); 

        }

        public void PutMarkByComputer(int player, int point) // Computer 가 놓는 말에 대한 함수 
        {           
            playerMark = 'O';
            
            do  // 픞레이어가 같은 자리에 뒀는지 확인
            {

                if ((point == 1) && (arraryMark[0] == '1') ||
                    (point == 2) && (arraryMark[1] == '2') ||
                    (point == 3) && (arraryMark[2] == '3') ||
                    (point == 4) && (arraryMark[3] == '4') ||
                    (point == 5) && (arraryMark[4] == '5') ||
                    (point == 6) && (arraryMark[5] == '6') ||
                    (point == 7) && (arraryMark[6] == '7') ||
                    (point == 8) && (arraryMark[7] == '8') ||
                    (point == 9) && (arraryMark[8] == '9'))
                {
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

                    correctPoint = true;

                }

                else
                {
                    point = random.Next(1, 10);
                    correctPoint = false;
                    Console.Clear();
                }

            } while (!correctPoint);

        }





        public int JudgeHoriziontal()
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
                    
                    return 1; // 1번 승리 기록 -> ScoreBoard 에서 사용 
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
                    
                    return 2; // 2번 승리 기록 -> ScoreBoard 에서 사용 
                }

                else
                {
                    return 0;
                }
            }

            else
            {
                return 0;
            }
        } // 가로로 빙고가 됐는지 판단
        
        public int JudgeVertical()
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

                    return 1; // 1번 승리 기록 -> ScoreBoard 에서 사용 
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

                    return 2; // 2번 승리 기록 -> ScoreBoard 에서 사용 
                }

                else
                {
                    return 0;
                }
            }

            else
            {
                return 0;
            }
            
        }  // 세로로 빙고가 됐는지 판단

        public int JudgeDiagnal()
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

                    return 1; 
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

                    return 2;
                }
                
                else
                {
                    return 0;
                }
            }
            
            else
            {
                return 0;
            }
        } // 대각선으로 빙고가 됐는지 판단
    }   
}


