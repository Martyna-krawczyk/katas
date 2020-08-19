namespace TicTacToe
{
    public class Player
    {
        public Player(string name, string token, IInput input, IOutput output)
        {
            Name = name;
            Token = token;
            _input = input;
            _output = output;
        }

        private IOutput _output { get; set; }
        private IInput _input { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        
        public string PlayMove()
        {
            _output.OutputText(string.Format(Resources.TakeTurn, Name));
            return GetPlayerMove(_input.InputText());
        }

        public string GetPlayerMove(string input)
        {
            return input;
        }
    }

    
}