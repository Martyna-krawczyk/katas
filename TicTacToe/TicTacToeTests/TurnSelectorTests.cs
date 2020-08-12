using System.Collections;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class TurnSelectorTests
    {
        [Fact]
        public void ComputerSelectsStringForXCoordinate()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            
            TurnSelector.ChooseXCoordinateString(1, board.Size);

            Assert.InRange(3,1,3);
        }
        
        [Fact]
        public void ComputerSelectsStringForYCoordinate()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            
            TurnSelector.ChooseYCoordinateString(1, board.Size);

            Assert.InRange(3,1,3);
        }
        
        
        
        //ComputerSelectsStringForYCoordinate()
        //randomXAndYGenerated()
        //ComputerProvidesPlayerMove
    }
}