using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC
{
    class Program
    {
        public static string word = "BOOK";
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

        public static void SearchBlocks(string word)
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                foreach (var letter in wordArray)
                {
                    if (Blocks[i].Side1.Contains(letter))
                    {
                        //Blocks.RemoveAt(i);
                        Console.WriteLine($"I found the letter: {letter} - it's position is {i} on Side 1");
                    }
                    else if (Blocks[i].Side2.Contains(letter))
                    {
                        Console.WriteLine($"I found the letter: {letter} - it's position is {i} on Side 2");
                    }

                    while (Blocks[i].Side1.Contains(letter) && Blocks[i].Side2.Contains(letter)
                    ) // this doesn't return anything!?
                    {
                        Console.WriteLine($"The letter {letter} appears on the same block");
                    }
                }
            }
        }

        public bool IsBlockFound(string word) //comparing blocks
        {
            Block block1 = new Block("P", "C");
            Block block2 = new Block("Z", "M");
            block1.Equals(block2);
        }
    }
}
    
