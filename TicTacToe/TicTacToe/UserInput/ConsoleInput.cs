using System;

namespace TicTacToe
{
    public class ConsoleInput : IInput
    {
        public string InputText()
        {
            return Console.ReadLine()?.Trim();
        }

        public void PlayMove(IOutput output, Player player)
        {
            output.OutputText(string.Format(Resources.TakeTurn, player.Name));
        }
    }
}