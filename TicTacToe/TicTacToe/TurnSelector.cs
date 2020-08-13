using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public static class TurnSelector
    {
        

        public static int ChooseIntegerForCoordinate(int min, int boardSize)
        {
            var random = new Random();
            return random.Next(min, boardSize);
        }
    }
}
