using System;
using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestBoard : IBoard
    {
        public int Size { get; }
        
        public int CalledCount { get; private set; } = 0;
        
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
            CalledCount++;
            return _cellAvailableResults[CalledCount];
        }
        
        public Cell[,] GetCellArray()
        {
            return new Cell[0,0];
        }

        public List<List<string>> GetRowValues()
        {
            return new List<List<string>>();
        }
    }
}
