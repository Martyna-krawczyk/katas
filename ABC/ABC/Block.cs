using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    public class Block
    {
        public Block(string side1, string side2)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public string Side1 { get; set; }

        public string Side2 { get; set; }

        
    }
}