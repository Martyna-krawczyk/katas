namespace TicTacToe
{
    public class Cell
    {
        private enum CellProperties
        {
            
        }
        //enum for Cell properties
        public Cell(char placeholder, bool isUsed = false)
        {
            Placeholder = placeholder;
            IsUsed = isUsed;
        }

        public char Placeholder { get; set; }

        public bool IsUsed { get; set; }
    }
}