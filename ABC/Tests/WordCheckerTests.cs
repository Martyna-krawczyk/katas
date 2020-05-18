using System;
using System.Collections.Generic;
using ABC;
using ABC.Tests;
using Xunit;

namespace Tests
{
    public class WordCheckerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void BlockContainsLetter_ReturnsExpected(string word, bool expected)
        {
            var wordChecker = new WordChecker();
            
            var actual = wordChecker.CanBlocksMakeWord(word);
            
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"TREAT", true},
                new object[] {"COMMON", false},
                new object[] {"SQUAD", true},
                new object[] {"A", true},
                new object[] {"BARK", true},
                new object[] {"BOOK", false},
                new object[] {"FRAME", true},
                new object[] {"CONFUSE", true},
                new object[] {"MARTYNA", false},
                new object[] {"SARA", true},
                new object[] {"PEOPLE", true},
                new object[] {"YES", true},
                new object[] {"HOUSE", false},
                new object[] {"PARK", true},
                new object[] {"PETER", false},
            };
    }
}