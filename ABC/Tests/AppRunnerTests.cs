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
        public void ConsoleOutputForDefaultWords_ReturnsExpected(bool result, string word, string expected)
        {
            var output = new TestOutput();
            var input = new ConsoleInput();
            var wordChecker = new TestWordChecker();
            var appRunner = new AppRunner(output, wordChecker, input);
            
            appRunner.RunWords(word);
            
            Assert.Equal(1, wordChecker.CalledCount);
            Assert.Equal(expected, output.CalledText);
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