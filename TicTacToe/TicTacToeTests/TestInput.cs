using TicTacToe;

namespace TicTacToeTests
{
    public class TestInput : IInput
    {
        public int CalledCount { get; set; }
        private string[] _inputs { get; set; }
        
        public TestInput(string[] inputs)
        {
            _inputs = inputs;
        }
        
        public string InputText()
        {
            return _inputs[CalledCount++];
        }
        
    }
}