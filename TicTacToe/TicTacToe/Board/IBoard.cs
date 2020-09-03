using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public interface IBoard
    {
        int Size { get; }
        void AssignTokenToCell(Player player, Coordinate coordinate);
        bool CellIsAvailable(Coordinate coordinate);
        IEnumerable<List<string>> GetAllBoardWinningLineValues();
        IEnumerable<bool> GetAllCellsAvailabilityFromBoard();
        Cell GetCell(int x, int y);
    }
}