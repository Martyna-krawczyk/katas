using ABC;

namespace Tests
{
    public class TestWordChecker : IWordChecker
    {
        private bool _result;
        public int CalledCount { get; set; }

        public TestWordChecker(bool result)
        {
            _result = result;
        }

        public bool CanBlocksMakeWord(string word)
        {
            CalledCount++;
            return _result;
        }

    }
}