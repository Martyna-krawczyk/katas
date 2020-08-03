using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public interface IBoard
    {
        int Size { get; }
        void PrintBoard();
        void AssignTokenToCell(Player player, Coordinate coordinate);
        bool CellIsAvailable(Coordinate coordinate);
        // IEnumerable<List<string>> GetRowValues();
        // IEnumerable<List<string>> GetColumnValues();
        IEnumerable<List<string>> GetDiagonalValues();
        IEnumerable<List<List<string>>> GetBoardWinningLinesValues();
    }
}