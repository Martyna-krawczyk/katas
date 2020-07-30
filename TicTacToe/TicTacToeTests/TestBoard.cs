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

        public IEnumerable<List<string>> GetRowValues()
        {
            return new List<List<string>>();
        }

        public IEnumerable<List<string>> GetColumnValues()
        {
            return new List<List<string>>();
        }

        public IEnumerable<List<string>> GetDiagonalValues()
        {
            return new List<List<string>>();
        }
    }
}
