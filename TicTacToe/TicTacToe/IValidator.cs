namespace TicTacToe
{
    public interface IValidator
    {
        bool IsValidFormat(string playerMove);
        bool IsValidCoordinate(Coordinate coordinate, IBoard board);
    }
}