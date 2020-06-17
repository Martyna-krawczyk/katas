using System;
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
            var runner = new AppRunner(input, output);

            runner.Run();
            
            Assert.Contains("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3 or 'q' to quit:", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }
        
        
        [Fact]
        public void ExitAppCalledOnQInput() 
        {
            var input = new TestInput(new string[] { "q"});
            var output = new TestOutput();
            var appRunner = new AppRunner(input, output);

            appRunner.Run();
            
            Assert.False(appRunner.Running);
            Assert.Equal(1, input.CalledCount);
        }
    }
}