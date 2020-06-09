using System;
using Xunit;

namespace TicTacToeTests
{
    public class Tests
    {
        [Theory]
        [InlineData("3,4")]
        [InlineData("6,7")]
        [InlineData("a,4")]
        [InlineData("wrong")]
        public void InvalidCoordinateReturnsException(string move)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var runner = new AppRunner(input, output);
            runner.Run();

            var exception = Assert.Throws<ArgumentException>(() => runner.Run());

            Assert.Equal("Sorry - that format is incorrect. Enter x ,y coordinates between 1-3:", exception.Message);
        }
    }
}