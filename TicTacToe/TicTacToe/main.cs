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

            Start start = new Start();
            Ask ask = new Ask();
            Play play = new Play();

            start.Introduction();
            //startOrNot = ask.AskWantStart();
            
            do
            {
                startOrNot = ask.AskWantStart();
                start.DetermineStartOrNot(startOrNot);
            }while(startOrNot != 1 && startOrNot != 2);
            
            gameType = ask.AskType();
            play.PaintBoard();
            
            switch(gameType)
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
            
        }
    }
}
