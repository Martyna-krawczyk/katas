using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Cell[,] _cell;
        private readonly IOutput _output;
        public int Size { get; set; }
        
        public Board(IOutput output, int size)
        {
            _output = output;
            Size = size;
            CreateBoard();
        }
        
        private void CreateBoard()
        {
            _cell = new Cell[Size, Size];
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _cell[x, y] = new Cell(".");
                }
            }
        }
        
        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).Value = player.Token;
            MarkCellAsUsed(coordinate);
        }
        
        public bool IsValidCoordinate(Coordinate coordinate)
        {
            return coordinate.X < Size && coordinate.X >= 0 && coordinate.Y < Size && coordinate.Y >= 0;
        }

        private void MarkCellAsUsed(Coordinate coordinate)
        {
            GetCellByCoordinates(coordinate).IsAvailable = false;
        }
        
        public bool CellIsAvailable(Coordinate coordinate)
        {
            return GetCellByCoordinates(coordinate).IsAvailable;
        }

        private Cell GetCellByCoordinates(Coordinate coordinate)
        {
            return _cell[coordinate.X, coordinate.Y];
        }
        public Cell[,] GetCellArray() //the .Clone creates a shallow copy
        {
            Cell[,] copy = _cell.Clone() as Cell[,];
            return copy;
        }
        public void PrintBoard()
        {
            _output.OutputText(
                string.Format(Prompts.BoardCoordinates, _cell[0,0].Value, _cell[0,1].Value, _cell[0,2].Value) 
                + Environment.NewLine 
                + string.Format(Prompts.BoardCoordinates, _cell[1,0].Value, _cell[1,1].Value, _cell[1,2].Value) 
                + Environment.NewLine 
                + string.Format(Prompts.BoardCoordinates, _cell[2,0].Value, _cell[2,1].Value, _cell[2,2].Value));
        }
    }
}
