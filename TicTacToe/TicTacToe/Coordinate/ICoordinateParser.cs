namespace TicTacToe
{
    public interface ICoordinateParser
    {
        public Coordinate GetNewCoordinate(string playerMove);
        public bool IsValidCoordinate(Coordinate coordinate, IBoard board);
        public bool IsValidFormat(string playerMove);
    }
}