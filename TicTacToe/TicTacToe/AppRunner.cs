using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        public bool Running { get; set; } = true;

        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly Board _board;
        private readonly CoordinateParser _coordinateParser;
        public AppRunner(IInput input, IOutput output, List<Player> players, Board board)
        {
            _input = input;
            _output = output;
            _players = players;
            _board = board;
            _coordinateParser = new CoordinateParser();
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

                var coordinate = _coordinateParser.GetCoordinates(playerMove);
                PlayMove(player, coordinate);
                //
                // if (ValidCoordinates(playerMove) ) // && board.IsUsed == false
                // {
                //     PlayMove(playerMove, player, _coordinate);
                // }
                // else
                // {
                //     _output.OutputText("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:");
                // }
            } while (!ValidCoordinates(playerMove));
            
        }

        private void PlayMove( Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.OutputText(Prompts.MoveAccepted);
            _board.PrintBoard();
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