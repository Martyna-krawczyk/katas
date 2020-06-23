using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private Cell[,] _cell;
        private readonly IOutput _output;
        public int _boardSize;
        private readonly Coordinate _coordinate;
        private readonly List<Player> _players;
        public Board(IOutput output, int boardSize, Coordinate coordinate, List<Player> players)
        {
            _output = output;
            _boardSize = boardSize;
            _coordinate = coordinate;
            _players = players;
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            _boardSize = 3;
            _cell = new Cell[_boardSize, _boardSize];
            for (var x = 0; x < _boardSize; x++)
            {
                for (var y = 0; y < _boardSize; y++)
                {
                    _cell[x, y] = new Cell(".");
                }
            }
        }

        public Cell GetCellByCoordinates(Coordinate coordinate)
        {
            return _cell[coordinate.X, coordinate.Y];
        }
        
        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            _cell[coordinate.X, coordinate.Y].Value = player.Token;
        }
        
        public void PrintBoard()
        {
            _output.OutputText(string.Format(Prompts.BoardCoordinates,_cell[0,0].Value, _cell[0,1].Value, _cell[0,2].Value));
            _output.OutputText(string.Format(Prompts.BoardCoordinates,_cell[1,0].Value, _cell[1,1].Value, _cell[1,2].Value));
            _output.OutputText(string.Format(Prompts.BoardCoordinates,_cell[2,0].Value, _cell[2,1].Value, _cell[2,2].Value));
        }
    }
}
