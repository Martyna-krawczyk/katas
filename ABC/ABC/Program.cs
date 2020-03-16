using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    class Program
    {
        public static void Main(string[] args)
        {
            string enteredString = "BARK";
            string matchedBlocks = "";

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
            //Console.WriteLine(blocksArray[0]);

            for (int i = 0; i < blocksArray.Count; i++)
            {
                if (blocksArray[i].Contains(enteredString))
                {
                    //Console.WriteLine(enteredString);
                    matchedBlocks = blocksArray[i].Where(blocksArray =>
                    {
                        return blocksArray.Contains(enteredString);
                    });
                    Console.WriteLine(matchedBlocks);
                }
            }
        }
    }
}


