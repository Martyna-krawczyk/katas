using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        const int Rows = 3;
        const int Columns = 3;
        private static bool _isUsed = false;
        public bool Running { get; private set; } = true;
        
        public int player = 2; 
        string move = "0,0";
        bool inputCorrect = true;
        static int turns = 0;
        public static char playerToken = ' ';
        
        private readonly IInput _input;
        private readonly IOutput _output;
        public AppRunner(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        readonly char[,] board = new char[Rows, Columns] { 
            {'.', '.', '.'}, 
            {'.', '.', '.'},
            {'.', '.', '.'}
        };
        
        
        public void Run()
        {
            _output.OutputText(Prompts.WelcomeMessage);
            _output.OutputText(Prompts.BoardIntro);
            PrintBoard(board);

            do
            {
                if (player == 2)
                {
                    player = 1;
                    Play(move);
                } else if (player == 1)
                {
                    player = 2;
                    Play(move);
                }
                turns++;
                PrintBoard(board);
                //Check for wins
                //check for draw
            } while (Running);
        }

        private void Play(string move)
        {
            Console.WriteLine("Player {0} enter a coord x,y to place your X or enter 'q' to give up:", player);
            move =_input.InputText();
            Console.WriteLine("Move accepted, here's the current board:");
            

            playerToken = player switch
            {
                1 => 'X',
                2 => 'O',
                _ => playerToken
            };

            switch (move)
            {
                case "q":
                    ExitApp();
                    break;
                case "1,1":
                    board[0,0] = playerToken;
                    break;
                case "1,2":
                    board[0,1] = playerToken;
                    break;
                case "1,3":
                    board[0,2] = playerToken;
                    break;
                case "2,1":
                    board[1,0] = playerToken;
                    break;
                case "2,2":
                    board[1,1] = playerToken;
                    break;
                case "2,3":
                    board[1,2] = playerToken;
                    break;
                case "3,1":
                    board[2,0] = playerToken;
                    break;
                case "3,2":
                    board[2,1] = playerToken;
                    break;
                case "3,3":
                    board[2,2] = playerToken;
                    break;
            }


           
            // if (ValidCoordinates(move))
            // {
            
            // }
            // else
            //     ThrowInvalidCoordinateException();
            //ConvertMoveToCoordinates(move);
            // }
        }

        

        private void IsUsed()
        {
            //if selected coordinate contains X or O
            //return _isUsed = true;
        }
        
        private static void ThrowInvalidCoordinateException() //need to fix something up here
            //Unhandled exception. System.ArgumentException: Sorry - that format is incorrect. Enter x ,y coordinates between 1-3:

        {
            throw new ArgumentException("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3:");
        }

        private static bool ValidCoordinates(string move)
        {
            var regex = new Regex(@"^[1-3],[1-3]$");
            return regex.IsMatch(move);
        }

        private void ExitApp()
        {
            Running = false;
        }

        private void PrintBoard(char[,] board)
        {
            Console.WriteLine(Prompts.BoardCoordinates,board[0,0], board[0,1], board[0,2]);
            Console.WriteLine(Prompts.BoardCoordinates,board[1,0], board[1,1], board[1,2]);
            Console.WriteLine(Prompts.BoardCoordinates,board[2,0], board[2,1], board[2,2]);
        }
    }
}