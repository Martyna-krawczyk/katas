using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class AppRunnerTests
    {
        [Fact]
        public void InvalidInputReturnsNotification()
        {
            var input = new TestInput(new string[] {"4,5", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(output);
            var runner = new AppRunner(input, output, players, board);

            runner.Run();
            
            Assert.Contains("Sorry - that coordinate is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }
        
        
        [Fact]
        public void ExitAppCalledOnQInput() 
        {
            var input = new TestInput(new string[] {"q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new Board(output);
            var runner = new AppRunner(input, output, players, board);

            runner.Run();
            
            Assert.False(runner.Running);
            Assert.Equal(1, input.CalledCount);
        }
    }
}