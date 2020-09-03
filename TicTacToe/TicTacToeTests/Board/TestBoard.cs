using System;
using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestBoard : IBoard
    {
        public int Size { get; }
        
        public int CalledCount { get; private set; }
        
        public TestBoard(bool[] cellAvailableResults)
        {
            _cellAvailableResults = cellAvailableResults;
        }
        
        private readonly bool[] _cellAvailableResults;

        public void PrintBoard()
        {
           
        }

        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            
        }

        public bool CellIsAvailable(Coordinate coordinate)
        {
            return _cellAvailableResults[CalledCount++];
        }

        public IEnumerable<List<string>> GetAllBoardWinningLineValues()
        {
            return new List<List<string>>();
        }

        public IEnumerable<bool> GetAllCellsAvailabilityFromBoard()
        {
            return new List<bool>();
        }

        public Cell GetCell(int x, int y)
        {
            return new Cell(".");
        }
    }
}
