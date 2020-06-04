namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        public AppRunner(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        public void Run()
        {
            _output.OutputText(Prompts.WelcomeMessage);
        }
    }
}