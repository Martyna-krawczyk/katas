namespace TicTacToe
{
    public interface IInput
    {
        string InputText();
        string PlayMove();
        string GetPlayerMove(string input);
    }
}