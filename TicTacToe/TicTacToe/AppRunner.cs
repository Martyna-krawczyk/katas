using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        
        public bool Running { get; private set; } = true;
       
       //Player Class
        public int Player = 2; 
        private char playerToken = ' ';
        
        //Player Cell
        public string Owner = " ";
        
        //Move Class
        public string PlayerMove = "0,0";
        static int turns = 0;
        int parsedXCoordinate;
        int parsedYCoordinate;
        private int boardCoordinates;
        
        const int x = 3;
        const int y = 3;
        private bool _isUsed = false;
        readonly char[,] _board = new char[x, y] { 
            {'.', '.', '.'}, 
            {'.', '.', '.'},
            {'.', '.', '.'}
        };

        private readonly IInput _input;
        private readonly IOutput _output;
        public AppRunner(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        
        public void Run()
        {
            _output.OutputText(Prompts.WelcomeMessage);
            _output.OutputText(Prompts.BoardIntro);
            PrintBoard(_board);

            do
            {
                switch (Player)
                {
                    case 2:
                        Player = 1;
                        Play();
                        break;
                    case 1:
                        Player = 2;
                        Play();
                        break;
                }
                turns++;
                CheckForHorizontalWin();
                //Check for wins - horizontal, vertical, diagonal
                //check for draw = turns == 10
            } while (Running);
        }

        private void CheckForHorizontalWin()
        {
            
        }

        private void Play()
        {
            _output.OutputText(string.Format(Prompts.TakeTurn, Player));
            
            PlayerMove =_input.InputText();
            
            playerToken = Player switch
            {
                1 => 'X',
                2 => 'O',
                _ => playerToken
            };
            
            if (PlayerMove == "q")
            {
                ExitApp();
            }
            if (ValidCoordinates(PlayerMove) ) // && cell.IsUsed == false
            {
                PlayMove();
            }
            // else
            //         //Not sure why this returns Unhandled Exception Unhandled exception. System.ArgumentException: Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:
            //         //at TicTacToe.AppRunner.Play() in /Users/martyna/RiderProjects/katas/TicTacToe/TicTacToe/AppRunner.cs:line 90
            //         //at TicTacToe.AppRunner.Run() in /Users/martyna/RiderProjects/katas/TicTacToe/TicTacToe/AppRunner.cs:line 52
            //         //at TicTacToe.Program.Main(String[] args) in /Users/martyna/RiderProjects/katas/TicTacToe/TicTacToe/Program.cs:line 12
            // {
            //     throw new ArgumentException("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:");
            // }
        }

        private void PlayMove()
        {
            AssignPlayerTokenToCoordinates(PlayerMove);
            _isUsed = true;
            Owner = playerToken.ToString();
            _output.OutputText(Prompts.MoveAccepted);
            PrintBoard(_board);
        }
        
        private void AssignPlayerTokenToCoordinates(string playerMove)
        {
            var xInput = playerMove[0].ToString();
            var yInput = playerMove[2].ToString();

            if (short.TryParse(xInput, out var xCoordinate))
            {
                parsedXCoordinate =  xCoordinate - 1;
            }
            
            if (short.TryParse(yInput, out var yCoordinate))
            {
                parsedYCoordinate =  yCoordinate - 1;
            }
            _board[parsedXCoordinate, parsedYCoordinate] = playerToken;
        }

        private static bool ValidCoordinates(string PlayerMove)
        {
            var regex = new Regex(@"^[1-3],[1-3]$");
            return regex.IsMatch(PlayerMove);
        }

        private void ExitApp()
        {
            Running = false;
        }

        private void PrintBoard(char[,] _board)
        {
            Console.WriteLine(Prompts.BoardCoordinates,_board[0,0], _board[0,1], _board[0,2]);
            Console.WriteLine(Prompts.BoardCoordinates,_board[1,0], _board[1,1], _board[1,2]);
            Console.WriteLine(Prompts.BoardCoordinates,_board[2,0], _board[2,1], _board[2,2]);
        }
        
        
    }
}