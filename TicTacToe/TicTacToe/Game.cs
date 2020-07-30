using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Game 
    {
        
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly IBoard _board;
        private readonly ICoordinateParser _coordinateParser;
        public bool Running { get; private set; } = true;

        public Game(IInput input, IOutput output, List<Player> players, IBoard board, ICoordinateParser coordinateParser)
        {
            _input = input;
            _output = output;
            _players = players;
            _board = board;
            _coordinateParser = coordinateParser;
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
                ProcessTurn(turns, player);
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

                Coordinate coordinate;
                if (_coordinateParser.IsValidFormat(playerMove))
                {
                    coordinate = SetCoordinate(playerMove);
                }
                else
                {
                    _output.OutputText(Prompts.IncorrectFormat);
                    _output.OutputText(string.Format(Prompts.TakeTurn, player.Name));
                    continue;
                }
                
                if (_coordinateParser.IsValidCoordinate(coordinate, _board))
                {
                    if (_board.CellIsAvailable(coordinate))
                    {
                        PlayMove(player, coordinate);
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

        private Coordinate SetCoordinate(string playerMove)
        {
            return _coordinateParser.GetCoordinates(playerMove);
        }
        
        private void ProcessTurn(int turns, Player player)
        {
            if (HasDraw(turns))
            {
                RunDraw();
            }
            else
            {
                if (!WinChecker.HasWin(player, _board)) return;
                RunWin(player);
            }
        }

        private void RunWin(Player player)
        {
            _output.OutputText(string.Format(Prompts.YouHaveWon, player.Name));
            ExitApp();
        }

        private void RunDraw()
        {
            _output.OutputText(Prompts.Draw);
            ExitApp();
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