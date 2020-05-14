using ABC;

namespace Tests
{
    public class TestWordChecker : IWordChecker
    {
        private bool Result { get; set; }
        private string CalledText { get; set; }
        public int CalledCount { get; set; }
        
        public bool CanBlocksMakeWord(string word)
        {
            CountIterations();
            CalledText = word;
            return Result;
        }

        private void CountIterations()
        {
            CalledCount++;
        }
    }
}