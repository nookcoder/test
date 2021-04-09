using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class DealExcept
    {
        Ask ask = new Ask();
        public int DealForAskWantStart(string startOrNot) // 입력된 값이 버튼 외의 경우일 때 처리 
        {
            int checkStartOrNot = 0; // 변수가 버튼의 있는 값인지 확인할 변수 

            for (int i = 0; i < startOrNot.Length; i++)
            {
                checkStartOrNot = checkStartOrNot * 10 + (startOrNot[i] - '0');
            } // 정수형으로 치환

            if (checkStartOrNot == 1 || checkStartOrNot == 2 || checkStartOrNot == 3)
            {
                return checkStartOrNot;
            }

            else
            {
                do
                {
                    Console.WriteLine("   -------------------------------- ");
                    Console.WriteLine("  | 버튼에 있는 것만 입력해주세요! |");
                    Console.WriteLine("   -------------------------------- ");
                    Thread.Sleep(2000);
                    Console.Clear();
                    startOrNot = ask.AskWantStart();
                    checkStartOrNot = 0;
                    for (int i = 0; i < startOrNot.Length; i++)
                    {
                        checkStartOrNot = checkStartOrNot * 10 + (startOrNot[i] - '0');
                    }

                } while (checkStartOrNot != 1 && checkStartOrNot != 2 && checkStartOrNot != 3);

                return checkStartOrNot;
            } // 원하는 값이 아닐 때 처리               
        }

        public int DealForAskGameType(string gameType) // 입력된 값이 버튼 외의 경우일 때 처리 
        {
            int checkGameType = 0; // 변수가 버튼의 있는 값인지 확인할 변수 

            for (int i = 0; i < gameType.Length; i++)
            {
                checkGameType = checkGameType * 10 + (gameType[i] - '0');
            } // 정수형으로 치환

            if (checkGameType == 1 || checkGameType == 2 || checkGameType == 3)
            {
                return checkGameType;
            }

            else
            {
                do
                {
                    Console.WriteLine("   -------------------------------- ");
                    Console.WriteLine("  | 버튼에 있는 것만 입력해주세요! |");
                    Console.WriteLine("   -------------------------------- ");
                    Thread.Sleep(2000);
                    Console.Clear();
                    gameType = ask.AskType();
                    checkGameType = 0;
                    for (int i = 0; i < gameType.Length; i++)
                    {
                        checkGameType = checkGameType * 10 + (gameType[i] - '0');
                    }

                } while (checkGameType != 1 && checkGameType != 2 && checkGameType != 3);

                return checkGameType;
            } // 원하는 값이 아닐 때 처리               
        }

        public int DealForAskReplay(string replayOrNot) // 입력된 값이 버튼 외의 경우일 때 처리 
        {
            int checkReplayOrNot = 0; // 변수가 버튼의 있는 값인지 확인할 변수 

            for (int i = 0; i < replayOrNot.Length; i++)
            {
                checkReplayOrNot = checkReplayOrNot * 10 + (replayOrNot[i] - '0');
            } // 정수형으로 치환

            if (checkReplayOrNot == 1 || checkReplayOrNot == 2)
            {
                return checkReplayOrNot;
            }

            else
            {
                do
                {
                    Console.WriteLine("   -------------------------------- ");
                    Console.WriteLine("  | 버튼에 있는 것만 입력해주세요! |");
                    Console.WriteLine("   -------------------------------- ");
                    Thread.Sleep(2000);
                    Console.Clear();
                    replayOrNot = ask.AskReplay();
                    checkReplayOrNot = 0;
                    for (int i = 0; i < replayOrNot.Length; i++)
                    {
                        checkReplayOrNot = checkReplayOrNot * 10 + (replayOrNot[i] - '0');
                    }

                } while (checkReplayOrNot != 1 && checkReplayOrNot != 2);

                return checkReplayOrNot;
            } // 원하는 값이 아닐 때 처리               
        }
    }
}
