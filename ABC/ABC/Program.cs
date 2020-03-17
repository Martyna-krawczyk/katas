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

            // Test changes for branch test
            // Perhaps the string being entered should have each letter separated into a new list?

            List<string> matchedBlocks = new List<string>();

            List<string> blocksArray = Blocks.AllTheBlocks;

            for (int i = 0; i < blocksArray.Count; i++)
            {
                if (blocksArray[i].Contains(enteredString))
                {
                    matchedBlocks.Add(enteredString);
                   
                    for (int m = 0; m < matchedBlocks.Count; m++)
                    {
                        Console.WriteLine(matchedBlocks[m]);
                    }
                }
            }
        }
    }
}
