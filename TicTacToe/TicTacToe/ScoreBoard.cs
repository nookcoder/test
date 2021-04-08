using System;
using System.Collections.Generic;
using System.Collections; 
using System.Text;

namespace TicTacToe
{
    public class ScoreBoard
    {
        public List<int> numberOfWin = new List<int>();

        public bool firstStartSetScoreBoard = true; // 점수판이 생성되었는 지 아닌 지 판단

        public void RecordScoreBoard(int winWho)  // 점수판에 기록하는 함수 
        {
            do
            {
                for (int numberOfWinIndex = 0; numberOfWinIndex < 3; numberOfWinIndex++)
                {
                    numberOfWin.Add(0);
                }
                firstStartSetScoreBoard = false;
            } while (firstStartSetScoreBoard); // 점수판 생성 (처음 호출한 것이 아니면 생성 안함) 

            switch (winWho)
            {
                case 1:
                    numberOfWin[0] += 1; // user 1 의 점수 추가
                    break;
                case 2:
                    numberOfWin[1] += 1; // user 2 의 점수 추가 
                    break;
                case 3:
                    numberOfWin[2] += 1; // computer 의 점수 추가 
                    break;
            }
        }

        public void PaintScoreBoard() // 점수판 출력 
        {

            Console.WriteLine("    ------------------------------------ ");
            Console.WriteLine("   |            이긴 횟수               |");
            Console.WriteLine("   |           User1 : {0}                |", numberOfWin[0]);
            Console.WriteLine("   |           User2 : {0}                |", numberOfWin[1]);
            Console.WriteLine("   |          Computer : {0}              |", numberOfWin[2]);
            Console.WriteLine("    ------------------------------------ ");

        }





        }



    }

