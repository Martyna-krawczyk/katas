using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerTurnCallsPlayMove()
        {
            var input = new ConsoleInput();
            var output = new TestOutput();
            var player = new Player("Human", "O");
            
            input.PlayMove(output, player);

            Assert.Contains("Human enter a coord x,y to place your X or enter 'q' to give up:", output.CalledText);
        }

    }
}