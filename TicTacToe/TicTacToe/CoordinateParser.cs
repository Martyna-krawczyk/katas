using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class CoordinateParser : ICoordinateParser
    {
        public static bool IsValidFormat(string playerMove)
        {
            var regex = new Regex(@"^\d,\d$");
            return regex.IsMatch(playerMove);
        }
        
        public bool IsValidCoordinate(Coordinate coordinate, IBoard board)
        {
            return coordinate.X < board.Size && coordinate.X >= 0 && coordinate.Y < board.Size && coordinate.Y >= 0;
        }
        
        public Coordinate GetCoordinates(string playerMove)
         {
             var stringCoordinates = playerMove.Split(",");
             var parsedXCoordinate = Convert.ToInt32(stringCoordinates[0]);
             var parsedYCoordinate = Convert.ToInt32(stringCoordinates[1]);
             var finalXCoordinate = parsedXCoordinate - 1;
             var finalYCoordinate = parsedYCoordinate - 1;
             return new Coordinate(finalXCoordinate,finalYCoordinate);
         }
        
    }
}