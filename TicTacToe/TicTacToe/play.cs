using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Play
    {
        Random random = new Random(); // 컴퓨터가 놓는 말을 위해 Random class 호출 
        Ask ask = new Ask();
        DealExcept dealExcept = new DealExcept();

        public bool iscorrectPoint; // 이미 놓은 위치에 다시 놓았는 지 확인하는 값
        public bool isdecidVictory = false; // 승패가 결정나면 True 로 변경 

        public const int firstTurn = 1;
        public const int secondTurn = 2;
        public int player = secondTurn; // 변수 초기화 
        
        public char playerMark; // player1 은 X , player2 는 O 로 표시 
        public string pointOfUser; // 말의 위치 
        public int checkPointOfUser; 
        public int pointOfComputer;

        public int countTurn = 0; // 턴 수 9번이 넘어가면 무승부
        public int countTurnOfComputer = 1; 

        public int winByVertical;
        public int winByHoriziontal;
        public int winByDiagnal; 

        public int winWho; //최종 승자가 누군지 저장 -> socreboard 에서 사용 예정 

        public static char[] arraryMark =
        {
        '1','2','3','4','5','6','7','8','9'
        }; // 플레이어가 말을 놓을 부분

        public int computer = 1;
        public int user = 2;

        public int i = 0;
        public int j = 0;
        public int computerPoint; 

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

        public void ResetGame() // 게임을 재시작 했을 떄 저장됐던 게임정보 초기화
        {
            char[] resetArrayMark =
            {
                '1','2','3','4','5','6','7','8','9'
            }; 
            int resetCountTurn = 0;
            bool isresetDecidVictory = false;
            int resetPlayer = 2; 

            arraryMark = resetArrayMark;
            countTurn = resetCountTurn;
            isdecidVictory = isresetDecidVictory;
            player = resetPlayer;
            countTurnOfComputer = resetCountTurn; // 각각 저장된 값 초기화 
        }

        // 게임 실행 함수 
        public int PlayGameWithUser() // vs User 를 선택했을 때 실행시킬 함수 
        {
            while (countTurn < 9 && !isdecidVictory) 
            { 
                if (player == secondTurn)
                {
                    player = firstTurn;
                    pointOfUser = ask.AskPoint();
                    checkPointOfUser = dealExcept.DealForAskPoint(pointOfUser);
                    PutMarkByUser(player, checkPointOfUser);
                }

                else if (player == firstTurn)
                {
                    player = secondTurn;
                    pointOfUser = ask.AskPoint();
                    checkPointOfUser = dealExcept.DealForAskPoint(pointOfUser);
                    PutMarkByUser(player, checkPointOfUser);
                } // 번갈아 가면서 말을 두도록 함

                countTurn++;
                Console.Clear();
                PaintBoard(); // 해당 칸에 말이 있는 보드 다시 그리기

                winByHoriziontal = JudgeHoriziontal(user);
                winByVertical = JudgeVertical(user);
                winByDiagnal = JudgeDiagnal(user);  // 승자가 있는 지 판단 (승리한 player 저장) 
            }
            
            // 9칸이 다 채워졌는 데도 승부가 안 났을 때 
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
        
        public int PlayGameWithComputer()
        {

            // 플레이어가 두면 컴퓨터는 랜덤하게 말을 둔다. 
            while (countTurn < 9 && !isdecidVictory)
            { 
                if (player == secondTurn)
                {
                    player = firstTurn;
                    pointOfUser = ask.AskPoint();
                    checkPointOfUser = dealExcept.DealForAskPoint(pointOfUser);
                    PutMarkByUser(player, checkPointOfUser);
                }

                else if (player == firstTurn)
                {
                    player = secondTurn;
                    pointOfComputer = PutPoint();
                    PutMarkByComputer(player, pointOfComputer);
                    countTurnOfComputer++; 
                }

                countTurn++;
                Console.Clear();
                PaintBoard();
                winByHoriziontal = JudgeHoriziontal(computer);
                winByVertical = JudgeVertical(computer);
                winByDiagnal = JudgeDiagnal(computer);

            }

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
            if(winWho == 2)
            {
                winWho += 1; 
            } // player2 가 이겼을 때 2를 반환하는 경우와 구별하기 위해 1을 더해준다. 
              // 컴퓨터가 이기면 3을 반환

            return winWho; 
        }  // vs Computer 를 선택했을 때 실행시킬 함수 

        // 게임 보드에 말을 표시하는 함수 
        public void PutMarkByUser(int player, int point) // User 가 놓는 말에 대한 함수 
        {

            if (player == firstTurn)
            {
                playerMark = 'X'; 
            }

            else if (player == secondTurn)
            {
                playerMark = 'O';
            } // 각 플레이어의 말 지정

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

                    iscorrectPoint = true; // do while 문 종료 

                }

                else // 말이 있는 자리에 두었을 때. 
                {
                    Console.WriteLine(" 이미 둔 자리입니다. 다시 선택해주세요! ");
                    point = Convert.ToInt32(Console.ReadLine());
                    iscorrectPoint = false; // 말의 위치 입력을 다시 함. 
                }

            } while (!iscorrectPoint); 

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

                    //pointOfComputer++; 
                    iscorrectPoint = true;

                }

                else
                {
                    point = random.Next(1, 10);
                    iscorrectPoint = false;
                }

            } while (!iscorrectPoint);

        }
        
        // 어떻게 이겼는 지 판단하는 함수
        public int JudgeHoriziontal(int who)
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
                    
                    isdecidVictory = true;
                    
                    return 1; // 1번 승리 기록 -> ScoreBoard 에서 사용 
                }
                
                else if(playerMark == 'O')
                {
                    if (who == user)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("    ===================================== ");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("   |   2번 플레이어 님이 승리하셨습니다  |");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("    ===================================== ");
                    }

                    else if(who == computer)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("    ===================================== ");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("   |      Computer 가 승리했습니다       |");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("    ===================================== ");
                    }

                    isdecidVictory = true;
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
        
        public int JudgeVertical(int who)
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

                    isdecidVictory = true;

                    return 1; // 1번 승리 기록 -> ScoreBoard 에서 사용 
                }
                
                else if (playerMark == 'O')
                {
                    if (who == user)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("    ===================================== ");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("   |   2번 플레이어 님이 승리하셨습니다  |");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("    ===================================== ");
                    }

                    else if (who == computer)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("    ===================================== ");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("   |      Computer 가 승리했습니다       |");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("    ===================================== ");
                    }

                    isdecidVictory = true;

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

        public int JudgeDiagnal(int who)
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
                   
                    isdecidVictory = true;

                    return 1; 
                }
                
                else if (playerMark == 'O')
                {
                    if (who == user)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("    ===================================== ");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("   |   2번 플레이어 님이 승리하셨습니다  |");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("    ===================================== ");
                    }

                    else if (who == computer)
                    {
                        Console.Clear();
                        Console.Clear();
                        Console.WriteLine("    ===================================== ");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("   |      Computer 가 승리했습니다       |");
                        Console.WriteLine("   |                                     | ");
                        Console.WriteLine("    ===================================== ");
                    }

                    isdecidVictory = true;

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

        public int PutPoint()
        {
            // 상대 2목 방어
            
            // 가로 확인
            if((arraryMark[0] == 'X' && arraryMark[1] == 'X') ||
               (arraryMark[0] == 'X' && arraryMark[1] == 'X') ||
               (arraryMark[0] == 'X' && arraryMark[1] == 'X'))
            {
                if(arraryMark[0] == '1')
                {
                    computerPoint = 1; 
                }

                else if(arraryMark[1] == '2')
                {
                    computerPoint = 2; 
                }

                else if(arraryMark[2] == '3')
                {
                    computerPoint = 3; 
                }
            }

            else
            {
                computerPoint = 0;
            }

            return 0; 
        }
    }


}   



