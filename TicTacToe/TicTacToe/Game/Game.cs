using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Game 
    {
        private readonly IOutput _output;
        private readonly IBoard _board;
        private readonly ICoordinateParser _coordinateParser;
        private readonly IValidator _validator;

        public GameStatus GameStatus { get; private set; }

        public Game(IOutput output, IBoard board, ICoordinateParser coordinateParser, IValidator validator)
        {
            _output = output;
            _board = board;
            _coordinateParser = coordinateParser;
            _validator = validator;
            GameStatus = GameStatus.InProgress;
        }
        
        public void Run(Player player)
        {
            GameValidator.TakeTurn(player, _board, _output, this, _validator,_coordinateParser);
            CheckGameRules(player);
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

        private void ExitApp()
        {
            GameStatus = GameStatus.GameOver;
        }
    }
}