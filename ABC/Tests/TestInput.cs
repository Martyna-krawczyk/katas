using System.Collections.Generic;
using System.Dynamic;
using ABC;

namespace Tests
{
    public class TestInput : IInput
    {
        public int CalledCount { get; set; }
        private string[] _inputs;

        public TestInput()
        {
        }

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