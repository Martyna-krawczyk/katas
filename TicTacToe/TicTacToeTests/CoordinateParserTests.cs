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
    }
    
}