namespace TicTacToe
{
    public interface IMove
    {
        public void Move(Player player);
        public void PlayMove(Player player, Coordinate coordinate);
    }
}