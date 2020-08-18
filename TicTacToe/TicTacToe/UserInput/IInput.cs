namespace TicTacToe
{
    public interface IInput
    {
        string InputText();

        void PlayMove(IOutput output, Player player);
    }
}