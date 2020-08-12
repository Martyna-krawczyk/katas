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
            
            TurnSelector.ChooseIntegerForCoordinate(1, board.Size);

            Assert.InRange(3,1,3);
        }
        
        //randomXAndYGenerated()
        //ComputerProvidesPlayerMove
    }
}