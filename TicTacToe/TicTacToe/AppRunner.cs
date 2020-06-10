using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        const int Rows = 3;
        const int Columns = 3;
        private bool _isUsed = false;
        readonly char[,] board = new char[Rows, Columns] { 
            {'.', '.', '.'}, 
            {'.', '.', '.'},
            {'.', '.', '.'}
        };
        
        public bool Running { get; private set; } = true;
        
        public int Player = 2; 
        public string PlayerMove = "0,0";
        
        static int turns = 0;
        private char playerToken = ' ';
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
            PrintBoard(board);

            do
            {
                if (Player == 2)
                {
                    Player = 1;
                    Play(PlayerMove);
                } else if (Player == 1)
                {
                    Player = 2;
                    Play(PlayerMove);
                }
                turns++;
                //Check for wins
                //check for draw
            } while (Running);
        }

        private void Play(string move)
        {
            _output.OutputText(string.Format(Prompts.TakeTurn, Player));
            
            PlayerMove =_input.InputText();
            
            playerToken = Player switch
            {
                1 => 'X',
                2 => 'O',
                _ => playerToken
            };

            switch (PlayerMove)
            {
                case "q":
                    ExitApp();
                    break;
                case "1,1":
                    PlayMove();
                    break;
                case "1,2":
                    PlayMove();
                    break;
                case "1,3":
                    PlayMove();
                    break;
                case "2,1":
                    PlayMove();
                    break;
                case "2,2":
                    PlayMove();
                    break;
                case "2,3":
                    PlayMove();
                    break;
                case "3,1":
                    PlayMove();
                    break;
                case "3,2":
                    PlayMove();
                    break;
                case "3,3":
                    PlayMove();
                    break;
                    default:
                        throw new ArgumentException("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3:");
                    
            }
            
        }

        private void PlayMove()
        {
            AssignPlayerTokenToCoordinates(PlayerMove);
            _isUsed = true;
            _output.OutputText(Prompts.MoveAccepted);
            PrintBoard(board);
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
            board[parsedXCoordinate, parsedYCoordinate] = playerToken;
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