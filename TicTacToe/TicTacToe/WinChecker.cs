using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToe
{
    public static class WinChecker
    {
        public static bool HasWin(Player player, IBoard board)
        {
            return HasWinOnBoard(player, board.GetBoardWinningLinesValues());
        }
        
        private static bool HasWinOnBoard(Player player, IEnumerable<List<string>> valuesList)
        {
            return valuesList.Select(lines => lines.All(value => value == player.Token))
                .Any(HasWin => HasWin);
        }
    }
}

