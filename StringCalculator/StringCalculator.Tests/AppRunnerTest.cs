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
        public void InputStringWithAnyAmountOfNumbersReturnsSumAsInt(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("1,2\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        [InlineData("//;\n1;2", 3)]
        public void InputStringWithMultipleDelimitersReturnsSumAsInt(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Fact]
        public void InputNegativeNumbersAsStringReturnsException()
        {
            var runner = new AppRunner();
            
            var exception = Assert.Throws<ArgumentException>(() => runner.Add("-1,2,-3"));
 
            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }
        
        [Theory]
        [InlineData("1000,1001,2", 2)]
        [InlineData("1100,2001,5,5", 10)]
        public void InputStringWithNumbersOver1000Ignored(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]
        public void InputStringWithFormattedDelimiter(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void InputStringWithMultipleFormattedDelimiters(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("//[***][#][%]\n1***2#3%4", 10)]
        public void InputStringWithMultipleFormattedDelimitersLongerThanOneCharacter(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
        
        [Theory]
        [InlineData("//[*1*][%]\n1*1*2%3", 6)]
        public void InputStringWithMultipleFormattedDelimitersIgnoringNumberIfEdgeIsNotOnDelimiter(string value, int expectedValue)
        {
            var runner = new AppRunner();

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }
    }
    
}