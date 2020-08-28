using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = new ConsoleOutput();
            var players = new List<Player>();
            
            Console.WriteLine(Resources.WelcomeMessage);
            var boardSize = UserSetsBoardSize();
            var board = new Board(output, boardSize);
            var numberOfPlayers = UserSetsNumberOfPlayers();
            var listOfPlayerTokens = GetPlayerTokenList(numberOfPlayers);
            var numberOfComputerPlayers = UserSetsNumberOfComputerPlayers();
            InitialisePlayerList(numberOfPlayers, numberOfComputerPlayers, players, listOfPlayerTokens, board);
            var coordinateParser = new CoordinateParser();
            var game = new Game(output, players, board, coordinateParser);
            
            game.Run();
        }
        
        private static int UserSetsBoardSize()
        {
            string boardSizeSelection;
            Console.WriteLine(Resources.BoardSizeRequest);
            do
            {
                boardSizeSelection = Console.ReadLine();
                CheckForValidInput(boardSizeSelection);
            } while (!IsValidFormat(boardSizeSelection));
            var size = int.Parse(boardSizeSelection);
            return size;
        }
        
        private static void CheckForValidInput(string input) 
        {
            if (!IsValidFormat(input))
            {
                Console.WriteLine(Resources.PleaseEnterOneNumberOnly);
            }
        }
        
        private static bool IsValidFormat(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]$");
        }
        
        private static int UserSetsNumberOfPlayers()
        {
            string numberOfPlayersSelection;
            do
            {
                Console.WriteLine(Resources.AskNumberOfPlayers);
                numberOfPlayersSelection = Console.ReadLine();
                CheckForValidInput(numberOfPlayersSelection);
            } while (!IsValidFormat(numberOfPlayersSelection));
        
            var numberOfPlayers = int.Parse(numberOfPlayersSelection);
            return numberOfPlayers;
        }
        
        private static int UserSetsNumberOfComputerPlayers()
        {
            string numberOfComputerPlayersSelection;
            do
            {
                Console.WriteLine(Resources.AskNumberOfComputerPlayers);
                numberOfComputerPlayersSelection = Console.ReadLine();
                CheckForValidInput(numberOfComputerPlayersSelection);
            } while (!IsValidFormat(numberOfComputerPlayersSelection));
        
            var numberOfComputerPlayers = int.Parse(numberOfComputerPlayersSelection);
            return numberOfComputerPlayers;
        }

        private static void InitialisePlayerList(int numberOfPlayers, int numberOfComputerPlayers, List<Player> players, List<string> listOfPlayerTokens, IBoard board)
        {
            InitialiseHumanPlayers(numberOfPlayers, numberOfComputerPlayers, players, listOfPlayerTokens);
            
            if (numberOfComputerPlayers > 0)
            {
                InitialiseComputerPlayers(numberOfComputerPlayers, players, board, listOfPlayerTokens);
            }
        }
        
        private static void InitialiseHumanPlayers(int numberOfPlayers, int numberOfComputerPlayers, List<Player> players, List<string> listOfPlayerTokens)
        {
            for (var i = 1; i <= numberOfPlayers - numberOfComputerPlayers; i++)
            {
                players.Add(new Player($"Player {i}", GetUniquePlayerToken(listOfPlayerTokens), new ConsoleInput()));
            }
        }
        
        private static void InitialiseComputerPlayers(int numberOfComputerPlayers, ICollection<Player> players, IBoard board, IList<string> listOfPlayerTokens)
        {
            for (var i = 1; i <= numberOfComputerPlayers; i++)
            {
                players.Add(new Player($"Computer {i}", GetUniquePlayerToken(listOfPlayerTokens), new BadComputerInput(board)));
            }
        }
        
        private static List<string> GetPlayerTokenList(int numberOfPlayers)
        {
            var tokens = new List<string> {"O","X"};
            do
            {
                for (var i = 1; i <= numberOfPlayers; i++)
                {
                    var playerToken = GenerateRandomPlayerToken();
                    if (!tokens.Contains(playerToken))
                    {
                        tokens.Add(playerToken);
                    }
                }
            } while (tokens.Count < numberOfPlayers);
            
            return tokens;
        }
        
        private static string GenerateRandomPlayerToken()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var num = random.Next(0, 26);
            var playerToken = characters.ElementAt(num).ToString();
            return playerToken;
        }
        
        private static string GetUniquePlayerToken(IList<string> tokens)
        {
            var token = tokens[0];
            tokens.RemoveAt(0);
            return token;
        }
    }
}
