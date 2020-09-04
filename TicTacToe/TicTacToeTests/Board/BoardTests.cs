using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void BoardSizeSetsSizeProperty()
        {
            var board = new Board(3);
            
            Assert.Equal(3, board.Size);
        }
        
        [Fact]
        public void AllCellsSetAsAvailableWhenInitialised()
        {
            var board = new Board(3);

            var cellsAvailabilityList = board.GetAllCellsAvailabilityFromBoard();

            Assert.All(cellsAvailabilityList, Assert.True);
        }

        [Fact]
        public void BoardWinningLineValuesListCountEquals8_ForBoardSize3()
        {
            var board = new Board(3);

            var boardWinningLineValuesCount = board.GetAllBoardWinningLineValues().Count();
            
            Assert.Equal(8, boardWinningLineValuesCount);
        }
        
        [Fact]
        public void PlayerTokenAssignedToCellValue()
        {
            var input = new ConsoleInput();
            var board = new Board(3);
            var player = new Player("Player 1", "X", input);
            var coordinate = new Coordinate(1,1);
            
            board.AssignTokenToCell(player, coordinate);
            
            Assert.Equal("X", player.Token );
        }
        
        [Fact]
        public void UsedCoordinateMarkedUnavailable()
        {
            var board = new Board(3);
            var coordinate = new Coordinate(1,1);
            
            var result = board.CellIsAvailable(coordinate);

            Assert.True(result);
        }
    }
}