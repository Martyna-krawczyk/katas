using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CoordinateParserTests
    {
        [Fact]
        public void ValidPlayerMoveReturnsCoordinate()
        {
            var coordinateParser = new CoordinateParser();
            
            var coordinate = coordinateParser.GetCoordinates("2,3");
            
            Assert.Equal(1,coordinate.X);
            Assert.Equal(2,coordinate.Y);
        }
        
        [Fact]
        public void ValidFormatReturnsTrue()
        {
            var coordinateParser = new CoordinateParser();
            
            var result = coordinateParser.IsValidFormat("1,3");
            
            Assert.True(result);
        } 
        
        [Fact]
        public void InValidFormatReturnsFalse()
        {
            var coordinateParser = new CoordinateParser();
            
            var result = coordinateParser.IsValidFormat("a,3");
            
            Assert.False(result);
        } 
        
        [Fact]
        public void ValidCoordinateReturnsTrue()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            var coordinate = new Coordinate(2,2);
            var coordinateParser = new CoordinateParser(); 

            var result = coordinateParser.IsValidCoordinate(coordinate, board);
            
            Assert.True(result);
        }
        
        [Fact]
        public void InValidCoordinateReturnsFalse()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            var coordinate = new Coordinate(2,7);
            var coordinateParser = new CoordinateParser(); 

            var result = coordinateParser.IsValidCoordinate(coordinate, board);
            
            Assert.False(result);
        }
    }
}