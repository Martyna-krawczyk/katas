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
        public void ConsoleOutputForDefaultWords_ReturnsExpected(string word, string expected)
        {
            var output = new TestOutput();
            var appRunner = new AppRunner(output);

            appRunner.PrintResultOfDefaultWords(word);
            
            Assert.Equal(expected, output.CalledText);
        }
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"TREAT", "True - We can spell TREAT with our blocks" },
                new object[] {"COMMON", "False - We can't spell COMMON with our blocks"},
                new object[] {"SQUAD", "True - We can spell SQUAD with our blocks"}
            };
    }
}