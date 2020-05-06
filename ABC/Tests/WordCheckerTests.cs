using System;
using System.Collections.Generic;
using ABC;
using Xunit;

namespace Tests
{
    public class WordCheckerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void BlockContainsLetter_ReturnsExpected(string word, bool expected)
        {
            WordChecker wordChecker = new WordChecker();
            
            var actual = wordChecker.CanBlocksMakeWord(word);
            
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"TREAT", true},
                new object[] {"COMMON", false},
                new object[] {"SQUAD", true}
            };
    }
}