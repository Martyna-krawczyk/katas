using System;

namespace TicTacToe
{
    public class Board
    {
        public Board(int row, int column, bool isPositionFree = false) 
        {
            Row = row;
            Column = column;
            IsPositionFree = isPositionFree;
        }
        
        private int Row { get; set; }
        private int Column { get; set; }
        private bool IsPositionFree { get; set; }
        
    }
}