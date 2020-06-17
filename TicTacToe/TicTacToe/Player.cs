namespace TicTacToe
{
    public class Player
    {
        public Player(string name, string token)
        {
            Name = name;
            Token = token;
        }
        
        public string Name { get; set; }
        public string Token { get; set; }
    }
}