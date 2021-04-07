using System;


namespace TicTacToe
{
    class TicTacToe
    {
        
        static void Main(string[] args)
        {
            int startOrNot;
            Start start = new Start();
            Ask ask = new Ask(); 

            start.Introduction();
            startOrNot = ask.AskWantStart();
            start.DetermineStartOrNot(startOrNot);
            ask.AskType();
        }
    }
}
