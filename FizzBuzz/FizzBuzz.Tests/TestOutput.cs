namespace FizzBuzz.Tests
{
    public class TestOutput : IOutput
    {
        public string CalledText { get; set; }
        public int CountNumberOfTimesOutputTextCalled { get; set; }
        
        public void OutputText(string text)
        {
            CalledText = text;
            CountIterations();
        }

        public void CountIterations()
        {
            CountNumberOfTimesOutputTextCalled++;
        }
        
        
    }
}