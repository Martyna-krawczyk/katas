using TicTacToe;

namespace TicTacToeTests
{
    public class TestCoordinateParser : ICoordinateParser
    {
        private readonly int _x;
        private readonly int _y;

        public TestCoordinateParser(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Coordinate GetCoordinates(string playerMove)
        {
            return new Coordinate(_x, _y);
        }
    }
}