using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace ABC
{
    public class WordBuilder
    {
        public List<Block> Blocks = new List<Block>()
        {
            new Block('B', 'O'),
            new Block('X', 'K'),
            new Block('D', 'Q'),
            new Block('C', 'P'),
            new Block('N', 'A'),
            new Block('G', 'T'),
            new Block('R', 'E'),
            new Block('T', 'G'),
            new Block('Q', 'D'),
            new Block('F', 'S'),
            new Block('J', 'W'),
            new Block('H', 'U'),
            new Block('V', 'I'),
            new Block('A', 'N'),
            new Block('O', 'B'),
            new Block('E', 'R'),
            new Block('F', 'S'),
            new Block('L', 'Y'),
            new Block('P', 'C'),
            new Block('Z', 'M')
        };

        
        public bool CanBlocksMakeWord(string word)
        {
            var usedBlocksCount = 0;

            ResetBlocks();
            
            foreach (var letter in word)
            {
                
                foreach (var block in Blocks)
                {
                    if (!block.IsUsed && block.HasLetter(letter))
                    {
                        block.IsUsed = true;
                        break; //move to the next letter in the word
                    }
                }

            }
            //all letters have now been checked against every block
            //count each used block to see if total matches the length of the word
            foreach (var block in Blocks)
            {
                if (block.IsUsed == true)
                {
                    usedBlocksCount++;
                    //Console.WriteLine("Block: {0} , {1}", block.Side1, block.Side2);
                }
            }
            //Console.WriteLine(usedBlocksCount); 
            return usedBlocksCount == word.Length;
        } 

        //resets all blocks back to isUsed = false after each word has finished
        private void ResetBlocks()
        {
            foreach (var block in Blocks)
            {
                block.IsUsed = false;
            }
        }
    }
}