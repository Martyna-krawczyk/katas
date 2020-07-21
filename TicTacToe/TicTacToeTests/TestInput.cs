using TicTacToe;

namespace TicTacToeTests
{
    public class TestInput : IInput
    {
        public int CalledCount { get; private set; }
        public string[] Inputs { get; set; }
        
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