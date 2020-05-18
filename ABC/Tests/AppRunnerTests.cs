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
        public void NumberOfTimesRunWordsCalled(bool result, string word, string expected)
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "2", word, "n"});
            var wordChecker = new TestWordChecker(result);
            var appRunner = new AppRunner(output, wordChecker, input);
            
            appRunner.Run();
            
            Assert.Equal(1, wordChecker.CalledCount);
            Assert.Contains(expected, output.CalledText);
            
        }

        [Fact]
        public void ExitAppCalledOnNInput() 
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "1", "y", "1", "n"});
            var wordChecker = new TestWordChecker(true);
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.False(appRunner.Running);
            Assert.Equal(4, input.CalledCount);
        }

        [Fact]
        public void ExitAppCalledOnSecondInput() 
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "1", "n"});
            var wordChecker = new TestWordChecker(false);
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.False(appRunner.Running);
            Assert.Equal(2, input.CalledCount);
        }

        [Fact]
        public void UserIsNotifiedForWrongInput() 
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "2", "gh65", "book", "n"});
            var wordChecker = new TestWordChecker(true);
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.Contains("Sorry, you can only enter letters - please try again.", output.CalledText);
        }
        
        [Fact]
        public void ExitAppIsCalledForNPlayAgainInput() 
        {
            var output = new TestOutput();
            var input = new TestInput(new string[] { "2", "book", "n"});
            var wordChecker = new TestWordChecker(true);
            var appRunner = new AppRunner(output, wordChecker, input);

            appRunner.Run();
            
            Assert.Contains("Okie - Bye!", output.CalledText);
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