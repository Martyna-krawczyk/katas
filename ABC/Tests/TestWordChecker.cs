using ABC;

namespace Tests
{
    public class TestWordChecker : IWordChecker
    {
        public bool Result { get; set; }
        public int CalledCount { get; set; }

        public bool CanBlocksMakeWord(string result)
        {
            CountIterations();
            return Result;
        }


        public void CountIterations()
        {
            CalledCount++;
        }

    }
}