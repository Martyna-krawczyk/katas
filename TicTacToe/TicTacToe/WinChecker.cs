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
            return HasHorizontalWin(player, board.GetBoardWinningLinesValues()) ||
                   HasVerticalWin(player, board.GetBoardWinningLinesValues()) ||
                   HasDiagonalWin(player, board.GetDiagonalValues());
        }

        private static bool HasDiagonalWin(Player player, IEnumerable<List<string>> diagonalValueList)
        {
            return diagonalValueList.Select(diagonals => diagonals.All(value => value == player.Token))
                .Any(HasWin => HasWin);
        }

        // private static bool HasHorizontalWin(Player player, IEnumerable<List<string>> horizontalValueList)
        // {
        //     return horizontalValueList.Select(rows => rows.All(value => value == player.Token)).Any(HasWin => HasWin);
        // }
        //
        // private static bool HasVerticalWin(Player player, IEnumerable<List<string>> verticalValueList)
        // {
        //     return verticalValueList.Select(columns => columns.All(value => value == player.Token)).Any(HasWin => HasWin);
        // }
        //
        // private static bool HasDiagonalWin(Player player, IEnumerable<List<string>> diagonalValueList)
        // {
        //     return diagonalValueList.Select(diagonals => diagonals.All(value => value == player.Token)).Any(HasWin => HasWin);
        // }

        private static bool HasHorizontalWin(Player player, IEnumerable<List<List<string>>> winningLinesList)
        {

            foreach (var listCollection in winningLinesList)
            {
                foreach (var line in listCollection)
                {
                    var lineHasWin = line.All(value => value == player.Token);
                    if (!lineHasWin) continue;
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool HasVerticalWin(Player player, IEnumerable<List<List<string>>> winningLinesList)
        {
            foreach (var listCollection in winningLinesList)
            {
                foreach (var line in listCollection)
                {
                    var lineHasWin = line.All(value => value == player.Token);
                    if (!lineHasWin) continue;
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

