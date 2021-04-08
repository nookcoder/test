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
                play.PaintBoard();

                switch (gameType)
                {
                    case 1:
                        winWho = play.PlayGameWithComputer();
                        break;
                    case 2:
                        winWho = play.PlayGameWithUser();
                        break;
                        //case 3: 
                        //ShowBoard(); 
                }

                replayOrNot = ask.AskReplay();
            } while (replayOrNot == startGame);


        }

    }
}

