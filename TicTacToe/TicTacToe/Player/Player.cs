namespace TicTacToe
{
    public class Player
    {
        public Player(string name, Token token, IInput input)
        {
            Name = name;
            Token = token;
            Input = input;
        }
        private IInput Input { get; set; }
        public string Name { get; private set; }
        public Token Token { get; private set; }

        public string InputText()
        {
            return Input.InputText();
        }
    }
}