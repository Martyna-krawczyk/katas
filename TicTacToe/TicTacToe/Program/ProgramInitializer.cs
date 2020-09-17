using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public static class ProgramInitializer
    {
        public static List<Player> UserSetsPlayerPreference(IBoard board)
        {
            Console.WriteLine(Resources.AskIfGameAgainstComputer);
            string input;
            do
            {
                input = Console.ReadLine();
                if (input == "y" || input == "n") continue;
                Console.WriteLine(Resources.InvalidInput);
                Console.WriteLine(Resources.AskIfGameAgainstComputer);
            } while (input != "y" && input != "n");
            return input == "y" ? InitialiseHumanAgainstComputerPlayerList(board) : InitialiseHumanPlayerList();
        }

        private static List<Player> InitialiseHumanPlayerList()
        {
            var players = new List<Player>
            {
                new Player("Player 1", Token.O, new ConsoleInput()),
                new Player("Player 2", Token.X, new ConsoleInput())
            };
            return players;
        }
        
        private static List<Player> InitialiseHumanAgainstComputerPlayerList(IBoard board)
        {
            var players = new List<Player>
            {
                new Player("Player 1", Token.O, new ConsoleInput()),
                new Player("Computer", Token.X, new BadComputerInput(board))
            };
            return players;
        }
    }
}