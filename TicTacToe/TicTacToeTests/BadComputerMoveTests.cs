using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BadComputerMoveTests
    {
        [Fact]
        public void BadComputerPlayerTurnCallsPlayMove()
        {
            var input = new ConsoleInput();
            var output = new TestOutput();
            var board = new Board(output, 3);
            var compInput = new BadComputerMove(input, board);
           
            var player = new Player("BadComputer", "X", compInput, output);
            
            player.PlayMove();

            Assert.Contains("BadComputer enter a coord x,y to place your X or enter 'q' to give up:", output.CalledText);
        }

        [Fact]
        public void BadComputerSelectsIntForCoordinates()
        {
            var boardSize = 3;
            var output = new TestOutput();
            var input = new ConsoleInput();
            var board = new Board(output, boardSize);
            var compInput = new BadComputerMove(input, board);

            var result = compInput.ChooseIntegerForCoordinate();

            Assert.InRange(result,0,boardSize);
        }
        
        [Fact]
        public void BadComputerGetsCoordinate()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input, board);
            var randomInteger = compInput.ChooseIntegerForCoordinate();

            var coordinate = CoordinateParser.GetCoordinates(randomInteger, randomInteger);

            Assert.IsType<Coordinate>(coordinate);
            Assert.NotNull(coordinate);
        }
        
        [Fact]
        public void BadComputerGetsAvailableCoordinate()
        {
            var boardSize = 3;
            var output = new TestOutput();
            var board = new Board(output, boardSize);
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input, board);

            var coordinate = compInput.GetAvailableCell(board);
            
            Assert.True(board.CellIsAvailable(coordinate));
        }
        
        [Fact]
        public void AvailableCoordinateIsConvertedToString()
        {
            var boardSize = 3;
            var output = new TestOutput();
            var board = new Board(output, boardSize);
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input, board);

            var coordinate = compInput.GetAvailableCell(board);
            var coordinateAsString = CoordinateParser.ConvertCoordinateToString(coordinate);

            Assert.IsType<string>(coordinateAsString);
        }
    }
}