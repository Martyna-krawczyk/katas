namespace ABC.Tests
{
    public class TestOutput : IOutput
    {
        public string CalledText { get; set; }
        
        public void OutputText(string text)
        {
            CalledText = text;
        }

        public void OutputText(string text1, string text2, string text3, string text4)
        {
            CalledText = text1;
            CalledText = text2;
            CalledText = text3;
            CalledText = text4;
        }
    }
}