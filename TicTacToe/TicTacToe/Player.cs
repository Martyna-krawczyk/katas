namespace TicTacToe
{
    public class Player
    {
        public Player(string name, string token, IInput input)
        {
            Name = name;
            Token = token;
            Input = input;
        }
        private IInput Input { get; set; }
        public string Name { get; private set; }
        public string Token { get; private set; }
        
        public string PlayMove()
        {
            return GetPlayerMove(Input.InputText());
        }

        private static string GetPlayerMove(string input)
        {
            return input;
        }
    }
}