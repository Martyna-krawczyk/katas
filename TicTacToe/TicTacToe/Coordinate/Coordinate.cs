namespace TicTacToe
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString()
        {
            return $"{X + 1},{Y + 1}";
        }
    }
}