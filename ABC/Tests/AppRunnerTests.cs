using System.Collections.Generic;
using ABC;
using ABC.Tests;
using Xunit;

namespace Tests
{
    public class AppRunnerTests
    {
        [Fact]
        // [Theory] 
        // [MemberData(nameof(Data))]
        public void ConsoleOutputforDefaultWords_ReturnsExpected()
        {
            var output = new TestOutput();
            var appRunner = new AppRunner(output);
            
            appRunner.RunDefaultWords();
            
            Assert.Equal("Yes - We can spell {2} with our blocks\n", output.CalledText));
        }
        
        // public static IEnumerable<object[]> Data =>
        //     new List<object[]>
        //     {
        //         new object[] {"A"},
        //         new object[] {"BARK"},
        //         new object[] {"BOOK"},
        //         new object[] {"TREAT"},
        //         new object[] {"COMMON"},
        //         new object[] {"SQUAD"},
        //         new object[] {"CONFUSE"},
        //         
        //     };
    }
}