using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        public bool Running { get; set; } = true;
        private Coordinate _coordinate;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly IBoard _board;
        private readonly CoordinateParser _coordinateParser;
        public AppRunner(IInput input, IOutput output, List<Player> players, IBoard board)
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
            do
            {
                var playerMove = _input.InputText();
                
                if (playerMove == "q")
                {
                    ExitApp();
                    break;
                }

                if (IsValidFormat(playerMove))
                {
                    _coordinate = _coordinateParser.GetCoordinates(playerMove);
                }
                else
                {
                    _output.OutputText("Sorry - that format is incorrect. " +
                                       "Enter x ,y coordinates between 1-3 or 'q' to quit:");
                }
                
                if (_board.IsValidCoordinate(_coordinate) && _board.CellIsAvailable(_coordinate))
                {
                    PlayMove(player, _coordinate);
                    break;
                }
                _output.OutputText("Sorry - that cell is not available, or the coordinates are outside the bounds. " +
                                   "Enter x ,y coordinates between 1-3 or 'q' to quit:");
            } while (true);
        }

        private void PlayMove( Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.OutputText(Prompts.MoveAccepted);
            _board.PrintBoard();
        }

        private static bool IsValidFormat(string playerMove)
        {
            var regex = new Regex(@"^\d,\d$");
            return regex.IsMatch(playerMove);
        }

        private void ExitApp()
        {
            Running = false;
        }

    }
}