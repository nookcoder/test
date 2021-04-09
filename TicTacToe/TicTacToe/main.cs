using System;


namespace TicTacToe
{
    class TicTacToe
    {

        static void Main(string[] args)
        {
            string startOrNot;
            int checkStartOrNot; 

            string gameType;
            int checkGameType;

            string replayOrNot;
            int checkReplayOrNot; 

            int winWho;
            int startGame = 1;
            int endGame = 2;

            Start start = new Start();
            Ask ask = new Ask();
            Play play = new Play();
            ScoreBoard scoreBoard = new ScoreBoard();
            DealExcept dealExcept = new DealExcept(); 

            start.Introduction();
            
            do
            {
                startOrNot = ask.AskWantStart();
                checkStartOrNot = dealExcept.DealForAskWantStart(startOrNot);
                start.DetermineStartOrNot(checkStartOrNot);
            } while (checkStartOrNot != startGame && checkStartOrNot != endGame);
            // 시작하기(1) 종료하기(2) 를 입력받으면 반복 종료 

            do
            {
                play.ResetGame();
                gameType = ask.AskType();
                checkGameType = dealExcept.DealForAskGameType(gameType);

                switch (checkGameType)
                {
                    case 1: // vs Computer 를 선택했을 때 
                        play.PaintBoard();
                        winWho = play.PlayGameWithComputer();
                        scoreBoard.RecordScoreBoard(winWho);
                        break;
                    case 2: // vs User 를 선택했을 때 
                        play.PaintBoard();
                        winWho = play.PlayGameWithUser();
                        scoreBoard.RecordScoreBoard(winWho);
                        break;
                    case 3: // ScoreBoard 를 선택했을 때 
                        scoreBoard.RecordScoreBoard(0);
                        scoreBoard.PaintScoreBoard();
                        break;
                }

                replayOrNot = ask.AskReplay();
                checkReplayOrNot = dealExcept.DealForAskReplay(replayOrNot);
            } while (checkReplayOrNot == startGame);

        }

    }
}

