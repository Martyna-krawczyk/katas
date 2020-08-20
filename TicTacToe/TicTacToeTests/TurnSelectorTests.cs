using System.Collections;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class TurnSelectorTests
    {
        [Fact]
        public void ComputerSelectsIntForCoordinates()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            
            var result = TurnSelector.ChooseIntegerForCoordinate(0, board.Size);

            Assert.InRange(result,0,3);
        }

        [Fact]
        public void ComputerSelectionGetsCoordinates()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);

            var selectionOne = TurnSelector.ChooseIntegerForCoordinate(0, board.Size);
            var selectionTwo = TurnSelector.ChooseIntegerForCoordinate(0, board.Size);
            
            var coordinate = CoordinateParser.GetCoordinates(selectionOne, selectionTwo);

            Assert.IsType<Coordinate>(coordinate);
            Assert.NotNull(coordinate);
        }
    }
}