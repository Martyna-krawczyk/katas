using TicTacToe;

namespace TicTacToeTests
{
    public class TestValidator : IValidator
    {
        private readonly bool _validCoordinateResults;
        private readonly bool _validFormatResults;
        
        public TestValidator(bool validCoordinateResults, bool validFormatResults)
        {
            _validCoordinateResults = validCoordinateResults;
            _validFormatResults = validFormatResults;
        }

        public bool IsValidCoordinate(Coordinate coordinate, IBoard board)
        {
            return _validCoordinateResults;
        }

        public bool IsValidFormat(string playerMove)
        {
            return _validFormatResults;
        }
    }
}