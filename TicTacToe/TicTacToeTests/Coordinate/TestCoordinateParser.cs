using TicTacToe;

namespace TicTacToeTests
{
    public class TestCoordinateParser : ICoordinateParser
    {
        private readonly bool _validCoordinateResults;
        private readonly bool _validFormatResults;
        
        public TestCoordinateParser(bool validCoordinateResults, bool validFormatResults)
        {
            _validCoordinateResults = validCoordinateResults;
            _validFormatResults = validFormatResults;
        }
        
        public Coordinate GetNewCoordinate(string playerMove)
        {
            return new Coordinate(0,0);
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