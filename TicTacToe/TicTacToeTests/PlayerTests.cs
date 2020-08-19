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
            var output = new TestOutput();
            var player = new Player("Human", "O", input, output);
            
        
            var result = player.GetPlayerMove("1,1");
        
            Assert.IsType<string>(result);
            Assert.Equal("1,1", result);
        }
    }
}