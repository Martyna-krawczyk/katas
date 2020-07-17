using System;
using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe
{
    public class WinRuleChecker
    {
        private readonly IBoard _board;
        private readonly List<string> _cellList;

        public WinRuleChecker(IBoard board, List<string> cellList)
        {
            _board = board;
            _cellList = cellList;
        }

        public bool HasWin(Player player)
        {
            return IsHorizontalWin(player, _cellList);
        }

        private bool IsHorizontalWin(Player player, List<string> _cellList)
        {
            return _cellList[0] == player.Token && _cellList[1] == player.Token && _cellList[2] == player.Token;
        }
    }
}

