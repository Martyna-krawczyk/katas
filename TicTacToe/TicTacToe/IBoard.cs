namespace TicTacToe
{
    public interface IBoard
    {
        public int Size { get; }
        void PrintBoard();
        bool IsValidCoordinate(Coordinate coordinate);
        void AssignTokenToCell(Player player, Coordinate coordinate);
        bool CellIsAvailable(Coordinate coordinate);
        string GetBoardCellValues(Coordinate coordinate);
    }
}