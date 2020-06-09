using System;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        const int Rows = 3;
        const int Columns = 3;
        private static bool _isUsed = false;
        
        
        private readonly IInput _input;
        private readonly IOutput _output;
        public AppRunner(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        private static string[][] _players = new string[][] { 
            new string[] { "Player1", "X" },
            new string[] { "Player2", "O" }    
        };
        
        const int Player1 = 0;
        const int Player2 = 1;
        
       
        
        char[,] board = new char[Rows, Columns] { 
            {'*', '*', '*'}, 
            {'*', '*', '*'},
            {'*', '*', '*'}
        };
        

        public void PrintBoard(char[,] board)
        {
            Console.WriteLine("{0} {1} {2}",board[0,0], board[0,1], board[0,2]);
            Console.WriteLine("{0} {1} {2}",board[1,0], board[1,1], board[1,2]);
            Console.WriteLine("{0} {1} {2}",board[2,0], board[2,1], board[2,2]);
        }
        
        public void Run()
        {
            _output.OutputText(Prompts.WelcomeMessage);
            _output.OutputText(Prompts.BoardIntro);
            PrintBoard(board);
        }
    }
}