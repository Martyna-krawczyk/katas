using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace ABC
{
    public class WordChecker : IWordChecker
    {
        private readonly List<Block> _blocks = new List<Block>()
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
            ResetBlocks();
            
            foreach (var letter in word)
            {
                foreach (var block in _blocks.Where(block => UnusedBlocksContainingLetter(block, letter)))
                {
                    block.IsUsed = true;
                    break; 
                }
            }
            var usedBlocksCount = _blocks.Count(block => block.IsUsed);
            return usedBlocksCount == word.Length;
        }

        private static bool UnusedBlocksContainingLetter(Block block, char letter)
        {
            return !block.IsUsed && block.HasLetter(letter);
        }

        private void ResetBlocks()
        {
            foreach (var block in _blocks)
            {
                block.IsUsed = false;
            }
        }
    }
}