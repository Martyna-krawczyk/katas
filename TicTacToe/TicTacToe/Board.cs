using System;

namespace TicTacToe
{
    public class Board
    {
        private Cell[,] _cell;
        private readonly IOutput _output;
        public Board(IOutput output)
        {
            _output = output;
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            _cell = new Cell[3, 3];
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    _cell[x, y] = new Cell(".");
                }
            }
        }

        public Cell GetCellByCoordinates(int x, int y)
        {
            return _cell[x, y];
        }
        
        public void PrintBoard()
        {
            _output.OutputText(String.Format(Prompts.BoardCoordinates,_cell[0,0].Value, _cell[0,1].Value, _cell[0,2].Value));
            _output.OutputText(String.Format(Prompts.BoardCoordinates,_cell[1,0].Value, _cell[1,1].Value, _cell[1,2].Value));
            _output.OutputText(String.Format(Prompts.BoardCoordinates,_cell[2,0].Value, _cell[2,1].Value, _cell[2,2].Value));
        }
    }
}
