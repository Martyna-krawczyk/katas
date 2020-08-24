using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class BadComputerInputTests
    {
        [Fact]
        public void BadComputerSelectsIntForCoordinates()
        {
            var boardSize = 3;
            var output = new TestOutput();
            var board = new Board(output, boardSize);
            var compInput = new BadComputerInput(board);

            var result = compInput.ChooseIntegerForCoordinate();

            Assert.InRange(result,0,boardSize);
        }
        
        [Fact]
        public void BadComputerGetsCoordinate()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            var compInput = new BadComputerInput(board);
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
            var compInput = new BadComputerInput(board);

            var coordinate = compInput.GetAvailableCell(board);
            
            Assert.True(board.CellIsAvailable(coordinate));
        }
        
        [Fact]
        public void AvailableCoordinateIsConvertedToString()
        {
            var boardSize = 3;
            var output = new TestOutput();
            var board = new Board(output, boardSize);
            var compInput = new BadComputerInput(board);

            var coordinate = compInput.GetAvailableCell(board);
            var coordinateAsString = CoordinateParser.ConvertCoordinateToString(coordinate);

            Assert.IsType<string>(coordinateAsString);
        }
    }
}