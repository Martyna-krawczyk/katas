using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TicTacToe
{
    public static class WinChecker
    {
        // public static bool HasWin(Player player, Cell[,] cell)
        // {
        //     //store these in an inner class??
        //     var horizontalList = new List<Tuple<int, bool>>(); 
        //     var verticalList = new List<Tuple<int, bool>>(); // tuple because the row int changes for each grouping
        //     var rtlDiagonalList = new List<bool>(); //tuple list not required for diagonal as rows / columns are fixed for each check
        //     var ltrDiagonalList = new List<bool>();
        //     
        //     var reverseIndex = cell.GetLength(0) -1; //this is used for the diagonal rtl where the index is reducing by row -1.
        //     
        //     for (var row = 0; row < cell.GetLength(0); row++) //dimension is the row index of cell array
        //     {
        //         ltrDiagonalList.Add(cell[row, row].Value == player.Token);
        //         rtlDiagonalList.Add(cell[row, reverseIndex].Value == player.Token); //cell[row, row-1].Value
        //         
        //         for (var col = 0; col < cell.GetLength(1); col++)//dimension is the column index of cell array
        //         { 
        //             horizontalList.Add(new Tuple<int, bool>(row, cell[row, col].Value == player.Token));
        //             verticalList.Add(new Tuple<int, bool>(col, cell[row, col].Value == player.Token));
        //         }
        //         reverseIndex--;
        //     }
        //
        //     return rtlDiagonalList.All(result => result) ||
        //            ltrDiagonalList.All(result => result) ||
        //            horizontalList.GroupBy(result => result.Item1)//.GroupBy groups by row, .Any goes through these IGroupings .All checks all for a true bool - this is true when one of the groupings returns true
        //                .Any(f => f.All(g => g.Item2)) ||
        //            verticalList.GroupBy(f => f.Item1)
        //                .Any(f => f.All(g => g.Item2));
        // }
        
        
        public static bool HasHorizontalWin(Player player, List<List<string>> horizontalValueList)
        {
            foreach (var rowList in horizontalValueList)
            {
                var rowHasWin = rowList.All(value => value == player.Token);
                if (!rowHasWin) continue;
                return true;
            }
            return false;
        }
    }
}

