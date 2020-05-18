using System.Collections.Generic;
using System.Dynamic;
using ABC;

namespace Tests
{
    public class TestInput : IInput
    {
        public string PlayAgainInputString { get; set; }
        public string SelectionInputString { get; set;}
        public int CalledCount { get; set; }
        
        public string InputText()
        {
            CountIterations();
            foreach (var VARIABLE in ReturnNextInput)
            {
                return VARIABLE;
            }

            return " ";
        }

        private IEnumerable<string> ReturnNextInput
        {
            get { yield return "1";
                yield return "y";
                yield return "n";
            }
        }
        

            public void CountIterations()
        {
            CalledCount++;
        }

        
    }
}