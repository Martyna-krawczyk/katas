using System;
using System.Diagnostics.Tracing;
using Xunit;

namespace StringCalculator.Tests
{
    public class AppRunnerTest
    {
        //step 1
        [Fact]
        public void EmptyStringReturnsZero()
        {
            var input = new Input();
            var runner = new AppRunner(input);

            var actual = runner.Add(" ");

            Assert.Equal(0, actual);
        }

        [Theory]
        //step 2
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        //step 3
        [InlineData("1, 2", 3)]
        [InlineData("3, 5", 8)]
        //step 4
        [InlineData("1, 2, 3", 6)]
        [InlineData("3, 5, 3, 9", 20)]
        //step 5
        [InlineData("1,2\n3", 6)]
        [InlineData("3\n5\n3,9", 20)]
        //step 6
        [InlineData("//;\n1;2", 3)]
        //step 8
        [InlineData("1000,1001,2", 2)]
        [InlineData("1100,2001,5,5", 10)]
        //step 9
        [InlineData("//[***]\n1***2***3", 6)]
        //step 10
        [InlineData("//[*][%]\n1*2%3", 6)]
        //step 11
        [InlineData("//[***][#][%]\n1***2#3%4", 10)]
        //step 12
        [InlineData("//[*1*][%]\n1*1*2%3", 6)]
        [InlineData("//[*3*][%]\n1*3*2%3", 6)]
        [InlineData("//[&7&][%]\n3&7&2%3", 8)]
        public void InputReturnsSumOfIntegers_SatisfyingKataStepRules(string value, int expectedValue)
        {
            var input = new Input();
            var runner = new AppRunner(input);

            var actual = runner.Add(value);

            Assert.Equal(expectedValue, actual);
        }

        //step 7
        [Fact]
        public void InputNegativeNumbersAsStringReturnsException()
        {
            var input = new Input();
            var runner = new AppRunner(input);

            var exception = Assert.Throws<ArgumentException>(() => runner.Add("-1,2,-3"));

            Assert.Equal("Negatives not allowed: -1, -3", exception.Message);
        }
        
        [Fact]
        public void InvalidDelimiterReturnsException()
        {
            var input = new Input();
            var runner = new AppRunner(input);

            var exception = Assert.Throws<ArgumentException>(() => runner.Add("//[7&&][%]\n3&7&2%3"));

            Assert.Equal("Invalid delimiter passed.", exception.Message);
        }
    }
}