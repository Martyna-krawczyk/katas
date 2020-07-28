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
        public List<List<string>> GetRowValues();
        List<List<string>> GetColumnValues();
    }
}