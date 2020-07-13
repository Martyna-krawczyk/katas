using System.Collections.Generic;

namespace TicTacToe
{
    public class Cell
    {
        public Cell(string value, bool isAvailable = true) 
        {
            Value = value;
            IsAvailable = isAvailable;
        }

        public bool IsAvailable { get; set; }

        public string Value { get; set; }
    }
}