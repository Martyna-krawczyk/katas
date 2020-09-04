using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Validator : IValidator
    {
        public bool IsValidFormat(string playerMove)
        {
            var regex = new Regex(@"^\d,\d$");
            return regex.IsMatch(playerMove);
        }
        
        public bool IsValidCoordinate(Coordinate coordinate, IBoard board)
        {
            return coordinate.X < board.Size && coordinate.X >= 0 && coordinate.Y < board.Size && coordinate.Y >= 0;
        }
    }
}