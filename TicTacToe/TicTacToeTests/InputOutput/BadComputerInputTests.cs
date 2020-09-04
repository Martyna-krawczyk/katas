using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BadComputerInputTests
    {
        [Fact]
        public void SelectsIntForCoordinates()
        {
            var boardSize = 3;
            var board = new Board(boardSize);
            var compInput = new BadComputerInput(board);

            var result = compInput.ChooseIntegerForCoordinate();

            Assert.InRange(result,0,boardSize);
        }
        
        [Fact]
        public void GetsAvailableCoordinate()
        {
            var boardSize = 3;
            var board = new Board(boardSize);
            var compInput = new BadComputerInput(board);

            var coordinate = compInput.GetAvailableCell(board);
            
            Assert.True(board.CellIsAvailable(coordinate));
        }
        
        [Fact]
        public void AvailableCoordinateIsConvertedToString()
        {
            var input = new TestBadComputerInput();

            input.InputText();
        
            Assert.Equal("2,3", input.InputText());
        }
    }
}