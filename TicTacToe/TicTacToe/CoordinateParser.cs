using System;

namespace TicTacToe
{
    public class CoordinateParser
    {
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