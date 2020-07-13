namespace TicTacToe
{
    public interface ICoordinateParser
    {
        public Coordinate GetCoordinates(string playerMove);
    }
}