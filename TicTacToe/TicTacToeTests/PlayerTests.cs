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
            var input = new TestInput(new[] {"1,2", "q"});
            var output = new TestOutput();
            var player = new Player("Human", "O", input, output);
            
            player.PlayMove();

            Assert.Contains("Human enter a coord x,y to place your X or enter 'q' to give up:", output.CalledText);
        }
        
        [Fact]
        public void PlayMoveCallsGetPlayerMove()
        {
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input);
            var output = new TestOutput();
            var player = new Player("BadComputer", "X", compInput, output);

            var result = player.PlayMove();
            
            Assert.Equal("2,1", result);
        }
    }
}