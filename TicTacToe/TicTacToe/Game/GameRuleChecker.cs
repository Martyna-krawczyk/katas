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
            return HasWinOnBoard(player, board.GetAllBoardWinningLineValues());
        }
        
        private static bool HasWinOnBoard(Player player, IEnumerable<List<string>> boardValues)
        {
            return boardValues.Select(lines => lines.All(token => token == player.Token.ToString()))
                .Any(hasWin => hasWin);
        }
        
        public static bool HasDraw(IBoard board)
        {
            return IsDraw(board.GetAllBoardWinningLineValues());
        }

        private static bool IsDraw(IEnumerable<List<string>> boardValues)
        {
            var flattenedList = boardValues.SelectMany(x => x);
            return flattenedList.All(token => token != Token.None.ToString());
        }
    }
}
