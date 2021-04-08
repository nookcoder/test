using System;


namespace TicTacToe
{
    class TicTacToe
    {

        static void Main(string[] args)
        {
            int startOrNot;
            int gameType;
            int winWho;
            int replayOrNot;
            int startGame = 1;
            int endGame = 2;

            Start start = new Start();
            Ask ask = new Ask();
            Play play = new Play();
            ScoreBoard scoreBoard = new ScoreBoard(); 

            start.Introduction();
            do
            {
                startOrNot = ask.AskWantStart();
                start.DetermineStartOrNot(startOrNot);
            } while (startOrNot != startGame && startOrNot != endGame);

            do
            {
                play.ResetGame();
                gameType = ask.AskType();
                

                switch (gameType)
                {
                    case 1:
                        play.PaintBoard();
                        winWho = play.PlayGameWithComputer();
                        scoreBoard.RecordScoreBoard(winWho);
                        break;
                    case 2:
                        play.PaintBoard();
                        winWho = play.PlayGameWithUser();
                        scoreBoard.RecordScoreBoard(winWho);
                        break;
                    case 3:
                        scoreBoard.RecordScoreBoard(0);
                        scoreBoard.PaintScoreBoard();
                        break;
                        
                }

                replayOrNot = ask.AskReplay();
            } while (replayOrNot == startGame);


        }

    }
}

