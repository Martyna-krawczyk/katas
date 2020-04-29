using System;
using System.Collections.Generic;
using ABC;
using Xunit;

namespace ABC.Tests
{
    public class BlockShould
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void HaveLetterBOnAnySide_ReturnsTrue(char side1, char side2)
        {
            Block block = new Block(side1, side2);
            
            var actual = block.HasLetter('B');
            
            Assert.True(actual);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {'B', 'C'},
                new object[] {'C', 'B'},
            };

        [Fact]
        public void HaveLetterBOnAnySide_ReturnsFalse()
        {
            Block block = new Block('C', 'E');
            
            var actual = block.HasLetter('B');
            
            Assert.False(actual);
        }
        
        [Fact]
        public void HaveDefaultValueOfFalseForIsUsed()
        {
            Block block = new Block('A', 'C');

            var actual = block.IsUsed;
            
            Assert.False(actual);
        }
    }
}