using System;
using System.Diagnostics.Tracing;
using Xunit;

namespace StringCalculator.Tests
{
    public class AppRunnerTest
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var runner = new AppRunner();

            var actual = runner.Add(" ");

            Assert.Equal(0, actual);
        }
        
        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void InputStringReturnsMatchingIntValue(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("1, 2", 3)]
        [InlineData("3, 5", 8)]
        public void InputStringWithTwoNumbersReturnsSumAsInt(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
    }
}