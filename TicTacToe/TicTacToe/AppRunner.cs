using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        public bool Running { get; private set; } = true;
        
        //Board Class
        const int Rows = 3;
        const int Columns = 3;
        private bool _isUsed = false;
        readonly char[,] _board = new char[Rows, Columns] { 
            {'.', '.', '.'}, 
            {'.', '.', '.'},
            {'.', '.', '.'}
        };
        
       //Player Class
        public int Player = 2; 
        private char playerToken = ' ';
        
        //Move Class
        public string PlayerMove = "0,0";
        static int turns = 0;
        int parsedXCoordinate;
        int parsedYCoordinate;
        private int boardCoordinates;
        
        
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
                if (Player == 2)
                {
                    Player = 1;
                    Play();
                } else if (Player == 1)
                {
                    Player = 2;
                    Play();
                }
                turns++;
                //Check for wins - horizontal, vertical, diagonal
                //check for draw = turns == 10
            } while (Running);
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
            if (ValidCoordinates(PlayerMove))
            {
                PlayMove();
            }
            else
            {
                throw new Exception( "Sorry - that format is incorrect. Enter x ,y coordinates between 1-3:");
            }
                
        }

        private void PlayMove()
        {
            AssignPlayerTokenToCoordinates(PlayerMove);
            _isUsed = true;
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

        private void PrintBoard(char[,] board)
        {
            Console.WriteLine(Prompts.BoardCoordinates,board[0,0], board[0,1], board[0,2]);
            Console.WriteLine(Prompts.BoardCoordinates,board[1,0], board[1,1], board[1,2]);
            Console.WriteLine(Prompts.BoardCoordinates,board[2,0], board[2,1], board[2,2]);
        }
    }
}