using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [Fact]
        public void PrintBoardMethodPrintsCorrectBoardAsGenerated()
        {
            var output = new TestOutput();
            var board = new Board(output);
            
            board.PrintBoard();

            Assert.Contains(". . .\n. . .\n. . .", output.CalledText);
        }
        
    }
}