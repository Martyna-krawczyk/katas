using System.Collections.Generic;

namespace TicTacToe
{
    public class Cell
    {
        public Cell(string value, bool isUsed = false) // add IsUsed = false property
        {
            Value = value;
            IsUsed = isUsed;
        }

        public bool IsUsed { get; set; }

        public string Value { get; set; }
    }
}