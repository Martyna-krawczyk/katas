using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private Cell[,] _cell;
        private List<Cell> _cellList = new List<Cell>();
        private readonly IOutput _output;
        public int BoardSize;
        
        public Board(IOutput output )
        {
            _output = output;
            
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            BoardSize = 3;
            _cell = new Cell[BoardSize, BoardSize];
            for (var x = 0; x < BoardSize; x++)
            {
                for (var y = 0; y < BoardSize; y++)
                {
                    _cell[x, y] = new Cell(".");
                    _cellList.Add(_cell[x,y]); //this list might aid in winning logic
                }
            }
        }

        public Cell GetCellByCoordinates(Coordinate coordinate)
        {
            return _cell[coordinate.X, coordinate.Y];
        }
        
        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).Value = player.Token;
        }
        
        // private bool IsValidCoordinate(_coordinates)
        // {
        //     return finalXCoordinate <= BoardSize && finalXCoordinate > 0 
        //                                                 && finalYCoordinate <= BoardSize && finalYCoordinate > 0;
        // }
        
        public void PrintBoard()
        {
            _output.OutputText(string.Format(Prompts.BoardCoordinates,_cell[0,0].Value, _cell[0,1].Value, _cell[0,2].Value));
            _output.OutputText(string.Format(Prompts.BoardCoordinates,_cell[1,0].Value, _cell[1,1].Value, _cell[1,2].Value));
            _output.OutputText(string.Format(Prompts.BoardCoordinates,_cell[2,0].Value, _cell[2,1].Value, _cell[2,2].Value));
        }
    }
}
