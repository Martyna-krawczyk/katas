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
            var board = new Board(boardSize);
            var compInput = new BadComputerInput(board);

            var result = compInput.ChooseIntegerForCoordinate();

            Assert.InRange(result,0,boardSize);
        }
        
        [Fact]
        public void BadComputerGetsCoordinate()
        {
            var board = new Board(3);
            var compInput = new BadComputerInput(board);
            var randomInteger = compInput.ChooseIntegerForCoordinate();

            var coordinate = new Coordinate(randomInteger, randomInteger);

            Assert.IsType<Coordinate>(coordinate);
            Assert.NotNull(coordinate);
        }
        
        [Fact]
        public void BadComputerGetsAvailableCoordinate()
        {
            var boardSize = 3;
            var board = new Board(boardSize);
            var compInput = new BadComputerInput(board);

            var coordinate = compInput.GetAvailableCell(board);
            
            Assert.True(board.CellIsAvailable(coordinate));
        }
        
        [Fact]
        public void AvailableCoordinateIsConvertedToString()
        {
            var boardSize = 3;
            var board = new Board(boardSize);
            var compInput = new BadComputerInput(board);
        
            var coordinate = compInput.GetAvailableCell(board);
            var coordinateAsString = coordinate.ToString();
        
            Assert.IsType<string>(coordinateAsString);
        }
    }
}