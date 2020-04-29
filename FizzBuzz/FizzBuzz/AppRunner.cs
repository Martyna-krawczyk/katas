namespace FizzBuzz
{
    public class AppRunner : IAppRunner
    {
        private readonly IOutput _output;
        
        public AppRunner(IOutput output)
        {
            _output = output;
        }
        
        public void Run()
        {
            for (var i = 0; i < 100; i++)
            {
                CheckNumber(i);
            }
        }

        public void CheckNumber(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                _output.OutputText("FizzBuzz");
            }
            else if (i % 5 == 0)
            {
                _output.OutputText("Buzz");
            }
            else if (i % 3 == 0)
            {
                _output.OutputText("Fizz");
            }
            else
            {
                _output.OutputText(i.ToString());
            }
        }
    }
}