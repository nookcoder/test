using System;
using System.Collections.Generic;
using System.Collections; 
using System.Text;

namespace TicTacToe
{
    public class ScoreBoard
    {
        public List<int> numberOfWin = new List<int>();
        public bool firstStartSetScoreBoard = true;
        public int winFirstPlayer = 1;
        public int winSecondPlayer = 2;
        public int winComputer = 3; 

        public void RecordScoreBoard(int winWho)
        {
            do
            {
                for (int numberOfWinIndex = 0; numberOfWinIndex < 3; numberOfWinIndex++)
                {
                    numberOfWin.Add(0);
                }
                firstStartSetScoreBoard = false;
            } while (firstStartSetScoreBoard);

            switch (winWho)
            {
                case 1:
                    numberOfWin[0] += 1;
                    break;
                case 2:
                    numberOfWin[1] += 1;
                    break;
                case 3:
                    numberOfWin[2] += 1;
                    break;
            }
        }

        public void PaintScoreBoard()
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

