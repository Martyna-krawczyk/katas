using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace TicTacToe
{
    public class Game 
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<Player> _players;
        private readonly IBoard _board;
        private readonly ICoordinateParser _coordinateParser;
        public bool Running { get; set; } = true;
        

        public Game(IInput input, IOutput output, List<Player> players, IBoard board, ICoordinateParser coordinateParser)
        {
            _input = input;
            _output = output;
            _players = players;
            _board = board;
            _coordinateParser = coordinateParser;
        }
        
        
        public void Run()
        {
            var turns = 0;
            _output.OutputText(Resources.WelcomeMessage);
            _output.OutputText(Resources.BoardIntro);
            _board.PrintBoard();
            do
            {
                var player = _players[turns % _players.Count];
                if (player.Name == "Human")
                {
                    var human = new HumanPlay(_input, _output, _board, _coordinateParser, this);
                    human.Move(player);
                    CheckGameRules(player);
                }
                else
                {
                    var badComputer = new BadComputerPlay(_output, _board);
                    badComputer.Move(player);
                    CheckGameRules(player);
                }
                turns++;
            } while (Running);
        }
        
        private void CheckGameRules(Player player)
        {
            if (GameRuleChecker.HasDraw(_board))
            {
                RunDraw();
            }
            else
            {
                if (!GameRuleChecker.HasWin(player, _board)) return;
                RunWin(player);
            }
        }

        private void RunWin(Player player)
        {
            _output.OutputText(string.Format(Resources.YouHaveWon, player.Name));
            ExitApp();
        }

        private void RunDraw()
        {
            _output.OutputText(Resources.Draw);
            ExitApp();
        }

        public void ExitApp()
        {
            Running = false;
        }
    }
}