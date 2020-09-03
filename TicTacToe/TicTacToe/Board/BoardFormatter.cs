using System;

namespace TicTacToe
{
    public static class BoardFormatter
    {
        public static string PrintBoard(IBoard board)
        {
            var boardString = "";  
            for (var x = 0; x < board.Size; x++)
            {
                for (var y = 0; y < board.Size; y++)
                {
                    boardString += board.GetCell(x,y).Value + " ";
                }
                if (x < board.Size - 1)
                {
                    boardString += Environment.NewLine;
                }
            }
            return boardString;
        }
    }
}

