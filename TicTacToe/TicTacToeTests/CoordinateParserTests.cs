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
            
            var coordinate = coordinateParser.GetNewCoordinate("2,3");
            
            Assert.Equal(1,coordinate.X);
            Assert.Equal(2,coordinate.Y);
        }
        
        
    }
}