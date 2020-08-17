using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class MoveTests
    {
        [Fact]
        public void BoardPrintsWithCorrectCoordinates()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var player  = new Player("Human", "O");
            var board = new Board(output, 3);
            var coordinateParser = new CoordinateParser();
            var human = new HumanPlay(input, output, board, coordinateParser);
            var coordinate = new Coordinate(0, 0);

            human.PlayMove(player, coordinate);
            
            Assert.Contains("O . . \n. . . \n. . . ", output.CalledText);
        }
        
        [Fact]
        public void CellOutsideOfBoardBounds_ReturnsNotification()
        {
            var input = new TestInput(new[] {"4,5", "q"});
            var output = new TestOutput();
            var player  = new Player("Human", "O");
            var board = new TestBoard(new[] {false});
            var coordinateParser = new TestCoordinateParser( validCoordinateResults: false, true);
            var human = new HumanPlay(input, output, board, coordinateParser);

            human.Move(player);

            Assert.Contains("Oh no, those coordinates are outside the bounds of this board. Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }

        [Fact]
        public void CellNotAvailable_ReturnsNotification()
        {
            var input = new TestInput(new[] {"1,1", "q"});
            var output = new TestOutput();
            var player = new Player("Human", "O");
            var board = new TestBoard(new bool[] {false});
            var coordinateParser = new TestCoordinateParser( validCoordinateResults: true, true);
            var human = new HumanPlay(input, output, board, coordinateParser);

            human.Move(player);

            Assert.Contains("Oh no, a piece is already at this place! Try again...", output.CalledText);
            Assert.Equal(2, input.CalledCount);
        }
        
        [Fact]
        public void ValidPlayerMoveFormatDoesNotPrintError()
        {
            var input = new TestInput(new[] {"1,2", "q"});
            var output = new TestOutput();
            var player = new Player("Human", "O");
            var board = new TestBoard(new[] {true});
            var coordinateParser = new TestCoordinateParser(validCoordinateResults: true, true);
            var human = new HumanPlay(input, output, board, coordinateParser);

            human.Move(player);
            
            Assert.DoesNotContain("Sorry - that format is incorrect! Try again...", output.CalledText);
            Assert.Equal(1, board.CalledCount);
        }
    }
}