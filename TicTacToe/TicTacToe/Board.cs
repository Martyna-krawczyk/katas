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
            var copy = _cell.Clone() as Cell[,];
            return copy;
        }
        public void PrintBoard()
        {
            var boardString = "";
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    boardString +=_cell[x,y].Value + " ";
                }
                if (x < Size - 1)
                {
                    boardString += Environment.NewLine;
                }
            }
            _output.OutputText(boardString);
        }
    }
}
