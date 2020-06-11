namespace TicTacToe
{
    public class Cell
    {
        public Cell(string placeholder, bool isUsed = false)
        {
            Placeholder = placeholder;
            IsUsed = isUsed;
        }

        public string Placeholder { get; set; }

        public bool IsUsed { get; set; }
    }
}