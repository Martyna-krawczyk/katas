using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestBoard : IBoard
    {
        private readonly IOutput _testOutput;
        private Cell[,] _cell;
        private bool _result;
        public List<string> CalledText { get; set; } = new List<string>();
        public int CalledCount { get; set; }
        public TestBoard(IOutput testOutput )
        {
            _testOutput = testOutput;
            
            CreateBoard();
        }

        private void CreateBoard()
        {
           //a fake contains more complex implementations
           //may resemble a production implementation, albeit with some shortcuts
           const int boardSize = 3;
           _cell = new Cell[boardSize, boardSize];
           for (var x = 0; x < boardSize; x++)
           {
               for (var y = 0; y < boardSize; y++)
               {
                   _cell[x, y] = new Cell(".");
               }
           }
        }

        public void PrintBoard()
        {
            
        }

        public bool IsValidCoordinate(Coordinate coordinate)
        {
            CalledCount++;
            return _result;
            //stub - returns hard coded value
            //spy will also record that members were invoked
        }

        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            
        }
    }
}
