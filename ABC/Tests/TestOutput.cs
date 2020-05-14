namespace ABC.Tests
{
    public class TestOutput : IOutput
    {
        public string CalledText { get; set; }

        public void OutputText(string text)
        {
            CalledText = text;
        }
    }
}