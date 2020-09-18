using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Cell[,] _cell;
        
        public Board(int size)
        {
            Size = size;
            CreateBoard();
        }
        
        public int Size { get; }

        private void CreateBoard()
        {
            _cell = new Cell[Size, Size];
            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _cell[x, y] = new Cell();
                }
            }
        }
        
        public IEnumerable<List<string>> GetAllBoardWinningLineValues()
        {
            var linesValuesList = new List<List<string>>();
            var diagonalListLtr = new List<string>();
            var diagonalListRtl = new List<string>();
            
            var reverseIndexer = Size - 1;
            
            for (var row = 0; row < Size; row++)
            {
                var rowList = new List<string>();
                var columnList = new List<string>();

                diagonalListLtr.Add(_cell[row,row].Token.ToString());
                diagonalListRtl.Add(_cell[row, reverseIndexer].Token.ToString());
                
                for (var col = 0; col < Size; col++)
                {
                    rowList.Add(_cell[row,col].Token.ToString());
                    columnList.Add(_cell[col,row].Token.ToString());
                }
                reverseIndexer--;
                
                linesValuesList.Add(rowList);
                linesValuesList.Add(columnList);
            }
            linesValuesList.Add(diagonalListLtr);
            linesValuesList.Add(diagonalListRtl);
            return linesValuesList;
        }
        
        public void AssignTokenToCell(Player player, Coordinate coordinate)
        {
            GetCell(coordinate).Token = player.Token;
        }

        public bool CellIsAvailable(Coordinate coordinate)
        {
            return GetCell(coordinate).Token == Token.None;
        }
        
        public string GetCellTokenValue(int x, int y)
        {
            return _cell[x, y].TokenToString();
        }
        
        private Cell GetCell(Coordinate coordinate)
        {
            return _cell[coordinate.X, coordinate.Y];
        }
    }
}
