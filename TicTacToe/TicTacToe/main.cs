using System;


namespace TicTacToe
{
    class TicTacToe
    {
        
        static void Main(string[] args)
        {
            int startOrNot;
            int gameType; 

            Start start = new Start();
            Ask ask = new Ask();
            Play play = new Play();

            start.Introduction();
            startOrNot = ask.AskWantStart();
            start.DetermineStartOrNot(startOrNot);
            gameType = ask.AskType();
            play.PaintBoard();
        }
    }
}
