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
            return HasWin(player, board.GetRowValues()) ||
                   HasVerticalWin(player, board.GetColumnValues());
        }
        public static bool HasWin(Player player, List<List<string>> horizontalValueList)
        {
            foreach (var rowList in horizontalValueList)
            {
                var rowHasWin = rowList.All(value => value == player.Token);
                if (!rowHasWin) continue;
                return true;
            }
            return false;
        }
        public static bool HasVerticalWin(Player player, List<List<string>> verticalValueList)
        {
            foreach (var columnList in verticalValueList)
            {
                var columnHasWin = columnList.All(value => value == player.Token);
                if (!columnHasWin) continue;
                return true;
            }
            return false;
        }
    }
}

