using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void PrintBoardMethodPrintsCorrectBoardAsGenerated()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            
            board.PrintBoard();

            Assert.Contains(". . . \n. . . \n. . . ", output.CalledText);
        }
        
        [Fact]
        public void AllCellsSetAsAvailableWhenInitialised()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);

            var cellsAvailabilityList = board.GetAllCellsAvailabilityFromBoard();

            Assert.All(cellsAvailabilityList, Assert.True);
        }
        
        //board line values list = 8 items for size 3 board
        //player token assigned to cell
        //all board cells available property set to true when board is initialised
        //used coord is marked unavailable
        //coordinate set to cell object
        
    }
    
    
    
}