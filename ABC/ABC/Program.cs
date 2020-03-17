using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    class Program
    {
        public static void Main(string[] args)
        {
            string enteredString = "B";
            //Perhaps the string being entered should have each letter separated into a new list?

            List<string> matchedBlocks = new List<string>();

            List<string> blocksArray = new List<string>
            {
                "B O",
                "X K",
                "D Q",
                "C P",
                "N A",
                "G T",
                "R E",
                "T G",
                "Q D",
                "F S",
                "J W",
                "H U",
                "V I",
                "A N",
                "O B",
                "E R",
                "F S",
                "L Y",
                "P C",
                "Z M"
            };

            for (int i = 0; i < blocksArray.Count; i++)
            {
                if (blocksArray[i].Contains(enteredString))
                {
                    matchedBlocks.Add(enteredString);
                   
                    for (int m = 0; m < matchedBlocks.Count; m++)
                    {
                        Console.WriteLine(matchedBlocks[m], m);
                    }
                }
            }
        }
    }
}


