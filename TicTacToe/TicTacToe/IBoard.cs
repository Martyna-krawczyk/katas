namespace TicTacToe
{
    public interface IBoard
    {
        void PrintBoard();
        bool IsValidCoordinate(Coordinate coordinate);
        void AssignTokenToCell(Player player, Coordinate coordinate);
    }
}