using TicTacToe;

namespace TicTacToeTests
{
    public class TestCoordinateParser : ICoordinateParser
    {
       // public int CalledCount { get; private set; } = 0;
        
        public TestCoordinateParser(bool validCoordinateResults, bool validFormatResults)
        {
            _validCoordinateResults = validCoordinateResults;
            _validFormatResults = validFormatResults;
        }
        
        private readonly bool _validCoordinateResults;
        private readonly bool _validFormatResults;


        public Coordinate GetCoordinates(string playerMove)
        {
            return new Coordinate(0,0);
        }

        public bool IsValidCoordinate(Coordinate coordinate, IBoard board)
        {
            //CalledCount++;
            return _validCoordinateResults;
        }

        public bool IsValidFormat(string playerMove)
        {
            
            return _validFormatResults;
        }
    }
}