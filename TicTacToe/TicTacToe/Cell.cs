using System.Collections.Generic;

namespace TicTacToe
{
    public class Cell
    {
        public bool IsAvailable { get; set; }
        public string Value { get; set; }
        
        public Cell(string value, bool isAvailable = true) 
        {
            Value = value;
            IsAvailable = isAvailable;
        }
    }
}