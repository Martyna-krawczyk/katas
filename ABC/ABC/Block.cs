using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    public class Block
    {
        public Block(char side1, char side2, bool isUsed = false) //this bool default is false
        {
            Side1 = side1;
            Side2 = side2;
            IsUsed = isUsed;
        }

        public char Side1 { get; set; }

        public char Side2 { get; set; }
        
        public bool IsUsed { get; set; }

        public bool HasLetter(char letter)
        {
            return Side1 == letter || Side2 == letter;
        }
    }
}