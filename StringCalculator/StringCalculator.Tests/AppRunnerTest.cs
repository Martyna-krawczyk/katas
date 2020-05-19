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
        [InlineData("1, 2, 3", 6)]
        [InlineData("3, 5, 3, 9", 20)]
        public void InputStringWithAnyAmountNumbersReturnsSumAsInt(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        [InlineData("//;n1;2", 3)]
        public void InputStringWithMultipleDelimitersReturnsSumAsInt(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
    }
}