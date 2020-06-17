using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        private readonly Board _board;
        public bool Running { get; set; } = true;

        private readonly List<Player> _players;
        private readonly IInput _input;
        private readonly IOutput _output;
        public AppRunner(IInput input, IOutput output, List<Player> players)
        {
            _input = input;
            _output = output;
            _players = players;
            _board = new Board();
        }
        
        public void Run()
        {
            var turns = 0;
            _output.OutputText(Prompts.WelcomeMessage);
            _output.OutputText(Prompts.BoardIntro);
            _board.PrintBoard();

            do
            {
                
                var player = _players[turns % _players.Count];
                RunPlay(player);
                turns++;
                //Check for wins - horizontal, vertical, diagonal
                //check for draw = turns == 10
            } while (Running);
        }


        private void RunPlay(Player player)
        {
            _output.OutputText(string.Format(Prompts.TakeTurn, player.Name));
            string playerMove;
            do
            {
                playerMove =_input.InputText();
                
                if (playerMove == "q")
                {
                    ExitApp();
                    break;
                }
                if (ValidCoordinates(playerMove) ) // && board.IsUsed == false
                {
                    PlayMove(playerMove, player.Token);
                }
                else
                {
                    _output.OutputText("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:");
                }
            } while (!ValidCoordinates(playerMove));
            
        }

        private void PlayMove(string playerMove, string playerToken)
        {
            EstablishTokenCoordinates(playerMove, playerToken);
            _output.OutputText(Prompts.MoveAccepted);
            _board.PrintBoard();
        }
        
        private void EstablishTokenCoordinates(string playerMove, string playerToken)
        {
            int parsedXCoordinate = 0;
            int parsedYCoordinate = 0;
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
            _board.GetCellByCoordinates(parsedXCoordinate, parsedYCoordinate).Value = playerToken;
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

    }
}