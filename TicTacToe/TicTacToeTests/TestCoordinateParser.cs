using TicTacToe;

namespace TicTacToeTests
{
    public class TestCoordinateParser : ICoordinateParser
    {
        public int CalledCount { get; private set;}
        
        public TestCoordinateParser(bool[] validCoordinateResults)
        {
            _validCoordinateResults = validCoordinateResults;
        }
        
        private readonly bool[] _validCoordinateResults;
        

        public Coordinate GetCoordinates(string playerMove)
        {
            return new Coordinate(0,0);
        }

        public bool IsValidCoordinate(Coordinate coordinate, IBoard board)
        {
            CalledCount++;
            return _validCoordinateResults[CalledCount];
        }
    }
}