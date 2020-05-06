using System;
using System.Collections.Generic;
using ABC;
using Xunit;

namespace ABC.Tests
{
    public class BlockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void HasLetter_ReturnsExpected(char side1, char side2, bool expected)
        {
            Block block = new Block(side1, side2);
            
            var actual = block.HasLetter('B');
            
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {'B', 'C', true},
                new object[] {'C', 'B', true},
                new object[] {'C', 'E', false}
            };

        [Fact]
        public void HaveDefaultValueOfFalseForIsUsed()
        {
            Block block = new Block('A', 'C');

            var actual = block.IsUsed;
            
            Assert.False(actual);
        }
        
        
    }
}