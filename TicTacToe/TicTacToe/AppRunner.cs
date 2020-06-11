using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        private Cell[,] _cell;
        public bool Running { get; private set; } = true;
       
       //Player Class
        public int Player = 2; 
        private string _playerToken = "";

        //Move Class
        public string PlayerMove = "0,0";
        static int turns = 0;
        int parsedXCoordinate;
        int parsedYCoordinate;
        private int boardCoordinates;

        private string playerSelection;
        //PlayMove();

        private readonly IInput _input;
        private readonly IOutput _output;
        public AppRunner(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        
        public void Run()
        {
            var board = new Board();
            _output.OutputText(Prompts.WelcomeMessage);
            _output.OutputText(Prompts.BoardIntro);
            board.PrintBoard();

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
            
            _playerToken = Player switch
            {
                1 => "X",
                2 => "O",
                _ => _playerToken
            };
            
            if (PlayerMove == "q")
            {
                ExitApp();
            }
            if (ValidCoordinates(PlayerMove) ) // && board.IsUsed == false
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
            var board = new Board();
            EstablishTokenCoordinates(PlayerMove);
            //AssignPlayerTokenToCoordinates();
            //update the state of the cell
            //_cell.IsUsed = true;
            //Owner = playerToken.ToString();
            _output.OutputText(Prompts.MoveAccepted);
            board.PrintBoard();
        }
        
        private void EstablishTokenCoordinates(string playerMove)
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

            _cell[parsedXCoordinate, parsedYCoordinate].Placeholder = _playerToken;
            
            //_cell.SetValue(_playerToken, parsedXCoordinate, parsedYCoordinate);

            // var playerSelection = "_cell" + "[" + parsedXCoordinate + "," + parsedYCoordinate + "]";
            // Object playerSelectionSubstring = playerSelection.Substring(1,9);
            // return playerSelectionSubstring;
        }

        // private void AssignPlayerTokenToCoordinates(object selectedCell)
        // {
        //     //selectedCell = playerSelection
        //         playerSelection = _playerToken;
        //     //update placeholder
        // }
        
        

        private static bool ValidCoordinates(string PlayerMove)
        {
            var regex = new Regex(@"^[1-3],[1-3]$");
            return regex.IsMatch(PlayerMove);
        }

        private void ExitApp()
        {
            Running = false;
        }

    }
}