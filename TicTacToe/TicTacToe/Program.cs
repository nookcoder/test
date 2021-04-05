using System;

namespace TicTacToe
{
    class StartGame
    {
        public int Starting() // 게임시작 종료 함수 
        {
            int _wetherStart = 0; // 게임을 시작할 것인지 말건지 입력 받을 변수 
            string checkWetherStart; // 예외확인 변수 
            bool iswetherStart = false;

            while (!iswetherStart || (_wetherStart != 1 && _wetherStart != 2))  // 1 또는 2 가 입력되면 반복 중지  
            { 

                Console.WriteLine("1.시작하기 2.종료하기");
                checkWetherStart = Console.ReadLine();
                iswetherStart = int.TryParse(checkWetherStart, out _wetherStart);

            }

            return _wetherStart;  // 시작(1) 종료(2) 반환 

        }

        public int SelectType()
        {
            //1. vs Computer 
            //2. vs User 
            //3. vs ScoreBoard
            int _sortOfType = 0 ; // 게임종류 선택 
            string checkSortOfType; 
            bool issortOfType = false;
            while(!issortOfType || (_sortOfType != 1 && _sortOfType !=2 && _sortOfType != 3)){

                Console.WriteLine("1.vs Computer \n" +"2. vs User \n" + "3. ScoreBoard");
                checkSortOfType = Console.ReadLine();
                issortOfType = int.TryParse(checkSortOfType, out _sortOfType);

            }

            return _sortOfType ;

        }

    }

    class PlayGame
    {
        public void PlayWithComputer()
        {

        }

        public void PlayWithUser()
        {

        }

        public void ShowScoreBoard()
        {

        }

        public void RunGame(int type)
        {
            switch(type)
            {
                case 1:
                    PlayWithComputer();
                    break;

                case 2:
                    PlayWithUser();
                    break;

                case 3:
                    ShowScoreBoard();
                    break; 

            }
        }
    }

    class TicTacToe
    {
        static void Main(string[] args)
        {
            int wetherStart; // 게임 시작 종료 변수 (초기값은 시작) 
            int sortOfType; 
            StartGame startGame = new StartGame();
            PlayGame playGame = new PlayGame(); 

            
            wetherStart = startGame.Starting();
            while (wetherStart == 1)
            {
                sortOfType = startGame.SelectType();
                playGame.RunGame(sortOfType); 



                wetherStart = startGame.Starting();

            }
        }
    }
}
