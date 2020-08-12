using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public static class TurnSelector
    {
        private static readonly Random Random = new Random();
        
        public static int ChooseXCoordinateString(int min, int max)  
        {  
            return Random.Next(min, max);  
        }

        public static int ChooseYCoordinateString(int min, in int boardSize)
        {
            return Random.Next(min, boardSize);  
        }
    }
}
