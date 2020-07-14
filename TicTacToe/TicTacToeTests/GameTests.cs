using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class AppRunnerTests
    {
        [Fact]
        public void CellOutsideOfBoardBounds_ReturnsNotification()
        {
            var input = new TestInput(new string[] {"4,5", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {false}, new bool[] { });
            var runner = new AppRunner(input, output, players, board);

            runner.Run();

            Assert.Contains("Oh no, those coordinates are outside the bounds of this board. Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }

        [Fact]
        public void CellNotAvailable_ReturnsNotification()
        {
            var input = new TestInput(new string[] {"1,3", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {true}, new bool[] {false});
            var runner = new AppRunner(input, output, players, board);

            runner.Run();

            Assert.Contains(
                "Oh no, a piece is already at this place! Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }


        [Fact]
        public void ExitAppCalledOnQInput()
        {
            var input = new TestInput(new string[] {"q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new Board(output);
            var runner = new AppRunner(input, output, players, board);

            runner.Run();

            Assert.False(runner.Running);
            Assert.Equal(1, input.CalledCount);
        }

        [Fact]
        public void ValidPlayerMoveFormatDoesNotPrintError()
        {
            var input = new TestInput(new string[] {"1,3", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {true}, new bool[] {false});
            var runner = new AppRunner(input, output, players, board);

            runner.Run();
            
            Assert.DoesNotContain("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(0, board.CalledCount);
        }
        
        [Fact]
        public void InvalidPlayerMoveFormatDoesNotCallBoardIsValidCoordinate()
        {
            var input = new TestInput(new string[] {"1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new TestBoard(new bool[] {false}, new bool[] {false});
            var runner = new AppRunner(input, output, players, board);

            runner.Run();
            
            Assert.Contains("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(-1, board.CalledCount);
        }
        
        [Fact]
        public void BoardPrintsWithCorrectCoordinates()
        {
            var input = new TestInput(new string[] {"1,1", "q"});
            var output = new TestOutput();
            var players = new List<Player>() {new Player("Player 1", "X")};
            var board = new Board(output);
            var runner = new AppRunner(input, output, players, board);

            runner.Run();
            
            Assert.Contains("X . .\n. . .\n. . .", output.CalledText);
        }
    }
}