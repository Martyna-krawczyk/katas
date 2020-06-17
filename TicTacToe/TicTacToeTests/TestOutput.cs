using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestOutput : IOutput
    {
        public List<string> CalledText { get; set; } = new List<string>();
        
        public void OutputText(string text)
        {
            CalledText.Add(text);
        }
        
        
    }
}