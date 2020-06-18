using System.Collections.Generic;

namespace TicTacToe
{
    public class Cell
    {
        public Cell(string value)
        {
            Value = value;
        }
        
        public string Value { get; set; }
    }
}