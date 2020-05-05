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
                _output.OutputText(CheckNumber(i));
            }
        }

        public string CheckNumber(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (i % 5 == 0)
            {
                return "Buzz";
            }
            else if (i % 3 == 0)
            {
                return "Fizz";
            }
            else
            {
                return i.ToString();
            }
        }
    }
}