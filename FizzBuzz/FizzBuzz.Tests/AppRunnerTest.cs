using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace FizzBuzz.Tests
{
    public class AppRunnerTest
    {
        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void ShouldOutputFizzBuzzWhenNumberIsDivisibleByThreeAndFive(int number)
        {
            // arrange
            var output = new TestOutput();
            var runner = new AppRunner(output);

            // act
            runner.CheckNumber(number);

            // assert
            Assert.Equal("FizzBuzz", output.CalledText);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        public void ShouldOutputFizzWhenNumberIsDivisibleByThree(int number)
        {
            var output = new TestOutput();
            var runner = new AppRunner(output);

            runner.CheckNumber(number);

            Assert.Equal("Fizz", output.CalledText);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(80)]
        public void ShouldOutputBuzzWhenNumberIsDivisibleByFive(int number)
        {
            var output = new TestOutput();
            var runner = new AppRunner(output);

            runner.CheckNumber(number);

            Assert.Equal("Buzz", output.CalledText);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(11)]
        [InlineData(22)]
        public void ShouldOutputNumberWhenNumberIsNotDivisibleByThreeOrFive(int number)
        {
            var output = new TestOutput();
            var runner = new AppRunner(output);

            runner.CheckNumber(number);

            Assert.Equal($"{number}", output.CalledText);
        }
        
        
        [Fact]
        public void ShouldOutput100ForTotalIterationsOfOutputText()
        {
            var output = new TestOutput();
            var runner = new AppRunner(output);
            
            runner.Run();
            
            Assert.Equal(100, output.CountNumberOfTimesOutputTextCalled ); 
        }
    }
}