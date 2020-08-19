namespace TicTacToe
{
    public class Player
    {
        public Player(string name, string token, IInput input, IOutput output)
        {
            Name = name;
            Token = token;
            Input = input;
            Output = output;
        }

        private IOutput Output { get; set; }
        private IInput Input { get; set; }
        public string Name { get; private set; }
        public string Token { get; private set; }
        
        public string PlayMove()
        {
            Output.OutputText(string.Format(Resources.TakeTurn, Name));
            return GetPlayerMove(Input.InputText());
        }

        private static string GetPlayerMove(string input)
        {
            return input;
        }
    }
}