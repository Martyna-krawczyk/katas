namespace TicTacToe
{
    public class AppRunner : IAppRunner
    {
        private readonly IInput _input;
        public AppRunner(IInput input)
        {
            _input = input;
        }
        
    }
}