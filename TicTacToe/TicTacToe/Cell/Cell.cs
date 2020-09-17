using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Cell
    {
        public Cell()
        {
            Token = Token.None;
        }
        
        public Token Token { get; set; }
        
        public string TokenToString()
        {
            return Token switch
            {
                Token.None => ".",
                Token.O => "O",
                Token.X => "X",
                _ => ""
            };
        }
    }
}