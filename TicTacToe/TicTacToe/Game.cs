using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Game : IGame
    {
        public bool Running { get; private set; } = true;
        private Coordinate _coordinate;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly IBoard _board;
        private readonly CoordinateParser _coordinateParser;


        public Game(IInput input, IOutput output, List<Player> players, IBoard board)
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

                if (HasDraw(turns))
                {
                    _output.OutputText(Prompts.Draw);
                    ExitApp();
                }
                else
                {
                    if (!WinChecker.HasWin(player, _board.GetCellArray())) continue;
                    _output.OutputText(string.Format(Prompts.YouHaveWon, player.Name));
                    ExitApp();
                }
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

                if (CoordinateParser.IsValidFormat(playerMove))
                {
                    _coordinate = _coordinateParser.GetCoordinates(playerMove);
                }
                else
                {
                    _output.OutputText(Prompts.IncorrectFormat);
                    _output.OutputText(string.Format(Prompts.TakeTurn,player.Name));
                    continue;
                }
                
                if (_board.IsValidCoordinate(_coordinate))
                {
                    if (_board.CellIsAvailable(_coordinate))
                    {
                        PlayMove(player, _coordinate);
                        break;
                    }
                    _output.OutputText(string.Format(Prompts.CellUnavailable)); 
                }
                else
                {
                    _output.OutputText(string.Format(Prompts.OutsideOfBounds));
                }
                _output.OutputText(string.Format(Prompts.TakeTurn,player.Name));
            } while (true);
        }
        
        private static bool HasDraw(int turns)
        {
            return turns == 9;
        }
        
        private void PlayMove( Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.ClearConsole();
            _output.OutputText(Prompts.MoveAccepted);
            _board.PrintBoard();
        }
        
        private void ExitApp()
        {
            Running = false;
        }
    }
}