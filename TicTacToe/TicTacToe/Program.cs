using System;

namespace PlayGame
{
    class StartGame
    {
        public int Starting() // 게임시작 종료 함수 
        {
            int _wetherStart = 0; // 게임을 시작할 것인지 말건지 입력 받을 변수 
            string checkwetherStart; // 예외확인 변수 
            bool iswetherStart = false;

            while (!iswetherStart || (_wetherStart != 1 && _wetherStart != 2))
            {  // 1 또는 2 가 입력되면 반복 중지  

                Console.WriteLine("1.시작하기 2.종료하기");
                checkwetherStart = Console.ReadLine();
                iswetherStart = int.TryParse(checkwetherStart, out _wetherStart);

            }

            return _wetherStart;  // 시작(1) 종료(2) 반환 

        }




    }

    class TicTacToe
    {
        static void Main(string[] args)
        {
            int wetherStart = 1; // 게임 시작 종료 변수 (초기값은 시작) 
            StartGame startGame = new StartGame();
            while (wetherStart == 1)
            {
                wetherStart = startGame.Starting();
            }
        }
    }
}
