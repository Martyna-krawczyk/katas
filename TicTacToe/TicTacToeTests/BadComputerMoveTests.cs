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
            var compInput = new BadComputerMove(input, 3);
            var output = new TestOutput();
            var player = new Player("BadComputer", "X", compInput, output);
            
            player.PlayMove();

            Assert.Contains("BadComputer enter a coord x,y to place your X or enter 'q' to give up:", output.CalledText);
        }
        
        [Fact]
        public void BadComputerPlayMoveCallsGetPlayerMove()
        {
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input, 3);
            var output = new TestOutput();
            var player = new Player("BadComputer", "X", compInput, output);

            var result = player.PlayMove();
            
            Assert.Equal("2,1", result);
        }
        
        [Fact]
        public void BadComputerSelectsIntForCoordinates()
        {
            var boardSize = 3;
            var output = new TestOutput();
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input, boardSize);
            var board = new Board(output, boardSize);
             
            var result = compInput.ChooseIntegerForCoordinate();

            Assert.InRange(result,0,boardSize);
        }
        
        [Fact]
        public void BadComputerGetsCoordinate()
        {
            var boardSize = 3;
            var input = new ConsoleInput();
            var compInput = new BadComputerMove(input, boardSize);
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
            var compInput = new BadComputerMove(input, boardSize);

            var coordinate = compInput.GetAvailableCell(board);
            
            Assert.True(board.CellIsAvailable(coordinate));
        }
    }
}