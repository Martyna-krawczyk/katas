using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public static class ProgramInitializer
    {
        public static int UserSetsPlayerPreference()
        {
            
            Console.WriteLine(Resources.AskIfGameAgainstComputer);
            string input;
            int numberOfComputerPlayers;
            do
            {
                input = Console.ReadLine();
                numberOfComputerPlayers = input == "y" ? 1 : 0;
                
                if (input == "y" || input == "n") continue;
                Console.WriteLine(Resources.InvalidInput);
                Console.WriteLine(Resources.AskIfGameAgainstComputer);
                
            } while (input != "y" && input != "n");
            return numberOfComputerPlayers;
        }

        public static void InitialisePlayerList(int numberOfPlayers, int numberOfComputerPlayers, List<Player> players, List<string> tokens, IBoard board)
        {
            InitialiseHumanPlayers(numberOfPlayers, numberOfComputerPlayers, players, tokens);
            
            if (numberOfComputerPlayers > 0)
            {
                InitialiseComputerPlayers(players, board, tokens);
            }
        }
        
        private static void InitialiseHumanPlayers(int numberOfPlayers, int numberOfComputerPlayers, List<Player> players, List<string> tokens)
        {
            for (var i = 1; i <= numberOfPlayers - numberOfComputerPlayers; i++)
            {
                players.Add(new Player($"Player {i}", GetPlayerToken(tokens), new ConsoleInput()));
            }
        }
        
        private static void InitialiseComputerPlayers(ICollection<Player> players, IBoard board, IList<string> tokens)
        {
            players.Add(new Player("Computer", GetPlayerToken(tokens), new BadComputerInput(board)));
        }

        private static string GetPlayerToken(IList<string> tokens)
        {
            var token = tokens[0];
            tokens.RemoveAt(0);
            return token;
        }
    }
}