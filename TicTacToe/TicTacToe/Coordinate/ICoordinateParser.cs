namespace TicTacToe
{
    public interface ICoordinateParser
    {
        public Coordinate GetNewCoordinate(string playerMove);
    }
}