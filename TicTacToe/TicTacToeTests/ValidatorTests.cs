using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class ValidatorTests
    {
        [Fact]
        public void ValidFormatReturnsTrue()
        {
            var validator = new Validator();
            
            var result = validator.IsValidFormat("1,3");
            
            Assert.True(result);
        } 
        
        [Fact]
        public void InValidFormatReturnsFalse()
        {
            var validator = new Validator();
            
            var result = validator.IsValidFormat("a,3");
            
            Assert.False(result);
        } 
        
        [Fact]
        public void ValidCoordinateReturnsTrue()
        {
            var board = new Board(3);
            var coordinate = new Coordinate(2,2);
            var validator = new Validator();

            var result = validator.IsValidCoordinate(coordinate, board);
            
            Assert.True(result);
        }
        
        [Fact]
        public void InValidCoordinateReturnsFalse()
        {
            var board = new Board(3);
            var coordinate = new Coordinate(2,7);
            var validator = new Validator();

            var result = validator.IsValidCoordinate(coordinate, board);
            
            Assert.False(result);
        }
    }
}