using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Game 
    {
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly IBoard _board;
        private readonly ICoordinateParser _coordinateParser;
        public GameStatus GameStatus { get; private set; }

        public Game(IOutput output, List<Player> players, IBoard board, ICoordinateParser coordinateParser)
        {
            _output = output;
            _players = players;
            _board = board;
            _coordinateParser = coordinateParser;
            GameStatus = GameStatus.InProgress;
        }
        
        public void Run()
        {
            var turns = 0;
            _output.OutputText(Resources.WelcomeMessage);
            _output.OutputText(Resources.BoardIntro);
            _board.PrintBoard();
            do
            {
                var player = _players[turns % _players.Count];
                RunPlay(player);
                turns++;
                CheckGameRules(player);
            } while (GameStatus.Equals(GameStatus.InProgress));
        }
        
        private void RunPlay(Player player)
        {
            do
            {
                _output.OutputText(string.Format(Resources.TakeTurn, player.Name));
                var playerMove = player.PlayMove();
                if (ExitIntent(playerMove)) break;

                Coordinate coordinate;
                if (_coordinateParser.IsValidFormat(playerMove))
                {
                    coordinate = SetCoordinate(playerMove);
                }
                else
                {
                    _output.OutputText(Resources.IncorrectFormat);
                    continue;
                }
                
                if (_coordinateParser.IsValidCoordinate(coordinate, _board))
                {
                    if (_board.CellIsAvailable(coordinate))
                    {
                        RunMove(player, coordinate);
                        break;
                    }
                    _output.OutputText(string.Format(Resources.CellUnavailable)); 
                }
                else
                {
                    _output.OutputText(string.Format(Resources.OutsideOfBounds));
                }
            } while (true);
        }

        private bool ExitIntent(string playerMove)
        {
            if (playerMove != "q") return false;
            ExitApp();
            return true;
        }

        private Coordinate SetCoordinate(string playerMove)
        {
            return _coordinateParser.GetCoordinates(playerMove);
        }
        
        private void CheckGameRules(Player player)
        {
            if (GameRuleChecker.HasDraw(_board))
            {
                RunDraw();
            }
            else
            {
                if (!GameRuleChecker.HasWin(player, _board)) return;
                RunWin(player);
            }
        }

        private void RunWin(Player player)
        {
            _output.OutputText(string.Format(Resources.YouHaveWon, player.Name));
            ExitApp();
        }

        private void RunDraw()
        {
            _output.OutputText(Resources.Draw);
            ExitApp();
        }
        
        private void RunMove(Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.ClearConsole();
            _output.OutputText(Resources.MoveAccepted);
            _board.PrintBoard();
        }
        
        private void ExitApp()
        {
            GameStatus = GameStatus.GameOver;
        }
    }
}