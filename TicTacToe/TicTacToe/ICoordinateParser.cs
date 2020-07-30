namespace TicTacToe
{
    public interface ICoordinateParser
    {
        public Coordinate GetCoordinates(string playerMove);
        public bool IsValidCoordinate(Coordinate coordinate, IBoard board);
        public bool IsValidFormat(string playerMove);
    }
}