using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Sudoku
    {
        public Sudoku(int[,] tabel)
        {
            this.Matrix = tabel;
        }
        private int[,] matrixValue;
        public int[,] Matrix
        {
            get
            {
                return matrixValue;
            }
            set
            {
                matrixValue = value;
            }
        }
    }
}
