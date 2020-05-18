using System.Collections.Generic;
using ABC;
using ABC.Tests;
using Xunit;

namespace Tests
{
    public class AppRunnerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        //[InlineData("TREAT")]
        // [InlineData("COMMON")]
        // [InlineData("SQUAD")]
        public void NumberOfTimesRunWordsCalled(bool result, string word, string expected)
        {
            var output = new TestOutput();
            var input = new TestInput();
            var wordChecker = new TestWordChecker();
            var appRunner = new AppRunner(output, wordChecker, input);
            
            //appRunner.RunWords(word);
            
            Assert.Equal(1, wordChecker.CalledCount);
            
        }
        
        // [Theory]
        // [MemberData(nameof(Data))]
        // public void OutputForRunWords_ReturnsExpectedResultAndString(bool result, string word, string expected)
        // {
        //     var output = new TestOutput();
        //     var input = new TestInput();
        //     var wordChecker = new WordChecker();
        //     var appRunner = new AppRunner(output, wordChecker, input);
        //     
        //     appRunner.RunWords(word);
        //     
        //     Assert.Equal(result, wordChecker.CanBlocksMakeWord(word));
        //     Assert.Equal(expected, output.CalledText);
        // }
        
        [Theory]
        [MemberData(nameof(Data))]
        public void OutputForRunWords_ReturnsExpectedResultAndString(bool result, string word, string expected)
        {
            var output = new TestOutput();
            var input = new TestInput();
            var wordChecker = new WordChecker();
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.Equal(result, wordChecker.CanBlocksMakeWord(word));
            Assert.Equal(expected, output.CalledText);
        }
        
        [Fact]
        public void ExitAppCalledOnNInput() 
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "1", "y", "n"});
            var wordChecker = new WordChecker();
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.False(appRunner.Running);
            Assert.Equal(3, input.CalledCount);
        }

        [Fact]
        public void ExitAppCalledOnSecondInput() 
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "1", "n"});
            var wordChecker = new WordChecker();
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.False(appRunner.Running);
            Assert.Equal(2, input.CalledCount);
        }
        
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {true, "TREAT", "True - We can spell TREAT with our blocks" },
                new object[] {false, "COMMON", "False - We can't spell COMMON with our blocks"},
                new object[] {true, "SQUAD", "True - We can spell SQUAD with our blocks"}
            };
    }
}