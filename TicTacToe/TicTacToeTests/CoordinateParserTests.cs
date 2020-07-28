using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class CoordinateParserTests
    {
        [Fact]
        public void PlayerMoveStringReturnsCoordinate()
        {
            var coordinateParser = new CoordinateParser();
            
            var coordinate = coordinateParser.GetCoordinates("2,3");
            
            Assert.Equal(1,coordinate.X);
            Assert.Equal(2,coordinate.Y);
        }
        
        [Fact]
        public void ValidFormatReturnsCoordinate()
        {
            var result = CoordinateParser.IsValidFormat("a,3");
            
            Assert.False(result);
        } 
        
        [Fact]
        public void ValidCoordinateReturnsTrue()
        {
            var output = new TestOutput();
            var board = new Board(output, 3);
            var coordinate = new Coordinate(2,2);
            //var coordinateParser = new TestCoordinateParser(validCoordinateResults: new[] {true}); //this returns a System.IndexOutOfRangeException : Index was outside the bounds of the array.
            var coordinateParser = new CoordinateParser(); 

            var result = coordinateParser.IsValidCoordinate(coordinate, board);
            
            Assert.True(result);
            //Assert.Equal(2, coordinateParser.CalledCount);
        }
    }
    
}