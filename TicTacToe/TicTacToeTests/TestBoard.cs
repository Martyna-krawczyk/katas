using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestBoard : IBoard
    {
        private readonly bool[] _validCoordinateResults;
        private readonly bool[] _cellAvailableResults;
        private Cell _cell;
        public int Size { get; }
        public int CalledCount { get; set; } = -1;
        public TestBoard(bool[] validCoordinateResults, bool[] cellAvailableResults)
        {
            _validCoordinateResults = validCoordinateResults;
            _cellAvailableResults = cellAvailableResults;
        }
        
        public void PrintBoard()
        {
           
        }

        public bool IsValidCoordinate(Coordinate coordinate)
        {
            CalledCount++;
            return _validCoordinateResults[CalledCount];
        }

        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            
        }

        public bool CellIsAvailable(Coordinate coordinate)
        {
            return _cellAvailableResults[CalledCount];
        }

        public string GetBoardCellValues(Coordinate coordinate)
        {
            return "boardCell";
        }

        public Cell GetCellByCoordinates(Coordinate coordinate)
        {
            return _cell;
        }
    }
}
