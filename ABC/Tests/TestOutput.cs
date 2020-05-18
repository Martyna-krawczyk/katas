namespace ABC.Tests
{
    public class TestOutput : IOutput
    {
        public List<string> CalledText { get; set; } = new List<string>();
        
        

        public void OutputText(string text)
        {
            CalledText.Add(text);
        }
        
        
    }
}