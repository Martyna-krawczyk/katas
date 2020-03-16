using System;
using System.Linq;

namespace ABC
{
    class Program
    {
        public static void Main(string[] args)
        {
            public string enteredString = "BARK";
            public string matchedBlocks = "";

            string[] blocksArray = new string[20]
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

            for (int i = 0; i < blocksArray.Length; i++)
            {
                    if (blocksArray[i].Contains(enteredString))
                    {

                        //matchedBlocks = blocksArray[i];
                        string matchedBlocks = blocksArray.Where(blocksArray => blocksArray.Contains(enteredString));
                    }

           
             }
    }

}
