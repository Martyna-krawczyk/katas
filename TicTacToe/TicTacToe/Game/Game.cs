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
        private readonly IValidator _validator;

        public GameStatus GameStatus { get; private set; }

        public Game(IOutput output, List<Player> players, IBoard board, ICoordinateParser coordinateParser, IValidator validator)
        {
            _output = output;
            _players = players;
            _board = board;
            _coordinateParser = coordinateParser;
            _validator = validator;
            GameStatus = GameStatus.InProgress;
        }
        
        public void Run()
        {
            var turns = 0;
            _output.OutputText(Resources.BoardIntro); 
            _output.OutputText(BoardFormatter.PrintBoard(_board));
            do
            {
                var player = _players[turns % _players.Count];
                GameValidator.TakeTurn(player, _board, _output, this, _validator,_coordinateParser);
                turns++;
                CheckGameRules(player);
            } while (GameStatus.Equals(GameStatus.InProgress));
        }
        
        public bool ExitIntent(string playerMove)
        {
            if (playerMove != "q") return false;
            ExitApp();
            return true;
        }

        private void CheckGameRules(Player player)
        {
            if (GameRuleChecker.HasDraw(_board) && !GameRuleChecker.HasWin(player, _board))
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

        public void RunPlayerMove(Player player, Coordinate coordinate)
        {
            _board.AssignTokenToCell(player, coordinate);
            _output.ClearConsole();
            _output.OutputText(Resources.MoveAccepted);
            _output.OutputText(BoardFormatter.PrintBoard(_board));
        }

        public void ExitApp()
        {
            GameStatus = GameStatus.GameOver;
        }
    }
}