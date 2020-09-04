using System;
using TicTacToe;

namespace TicTacToeTests
{
    public class TestInput : IInput
    {
        public int CalledCount { get; private set; }
        private string[] Inputs { get; }
        
        public TestInput(string[] inputs)
        {
            Inputs = inputs;
        }
        
        public string InputText()
        {
            return Inputs[CalledCount++];
        }
    }
}