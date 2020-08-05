using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToe
{
    public static class GameRuleChecker
    {
        public static bool HasWin(Player player, IBoard board)
        {
            return HasWinOnBoard(player, board.GetAllBoardLineValues());
        }
        
        private static bool HasWinOnBoard(Player player, IEnumerable<List<string>> boardValues)
        {
            return boardValues.Select(lines => lines.All(value => value == player.Token))
                .Any(HasWin => HasWin);
        }
        
        public static bool HasDraw(IBoard board)
        {
            return IsDraw(board.GetAllBoardLineValues());
        }
        
        private static bool IsDraw(IEnumerable<List<string>> boardValues)
        {
            return boardValues.All(list => !list.Any(value => value.Equals(".")));
        }
    }
}

