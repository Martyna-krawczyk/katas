namespace TicTacToe
{
    public class Board
    {
        public Board(int x, int y, string owner, bool isUsed = false)
        {
            _x = x;
            _y = y;
            Owner = owner;
            IsUsed = isUsed;
        }

        private int _x { get; set; }
        private int _y { get; set; }
        public string Owner { get; set; }
        public bool IsUsed { get; set; }

    }
}
