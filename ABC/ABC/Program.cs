using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    class Program
    {
        public static string word = "BARK";
        public static char[] wordArray = word.ToCharArray();
        public static void Main(string[] args)
        {
            SearchBlocks(word);
        }
        


        public static List<Block> Blocks = new List<Block>()
        {
            new Block("B", "O"),
            new Block("X", "K"),
            new Block("D", "Q"),
            new Block("C", "P"),
            new Block("N", "A"),
            new Block("G", "T"),
            new Block("R", "E"),
            new Block("T", "G"),
            new Block("Q", "D"),
            new Block("F", "S"),
            new Block("J", "W"),
            new Block("H", "U"),
            new Block("V", "I"),
            new Block("A", "N"),
            new Block("O", "B"),
            new Block("E", "R"),
            new Block("F", "S"),
            new Block("L", "Y"),
            new Block("P", "C"),
            new Block("Z", "M")
        };

        public static void NewArrayFromString(string word)
        {
            
        }
        
        public static void SearchBlocks(string word)
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                if (Blocks[i].Side1.Contains(word) || Blocks[i].Side2.Contains(word))
                {
                    foreach (var letter in wordArray)
                    {
                        for (int j = 0; j < wordArray.Length; j++)
                        {
                            Blocks.RemoveAt(i);
                        }
                    }
                    //Console.WriteLine($"Yes and the position is {i}");
                }
                    
            }
        }
        
        
        
    }
}
