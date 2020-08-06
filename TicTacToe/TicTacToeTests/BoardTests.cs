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

        [Fact]
        public void BoardWinningLineValuesListCountEquals8_ForBoardSize3()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);

            var boardWinningLineValuesCount = board.GetAllBoardWinningLineValues().Count();
            
            Assert.Equal(8, boardWinningLineValuesCount);
        }
        
        
        
        //player token assigned to cell
        //all board cells available property set to true when board is initialised
        //used coord is marked unavailable
        //coordinate set to cell object
        
    }
    
    
    
}