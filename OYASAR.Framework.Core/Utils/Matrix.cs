using System.Collections.Generic;

namespace OYASAR.Framework.Core.Utils
{
    public class Matrix
    {
        private readonly int _endRow = 0;
        private readonly int _endColumn = 0;

        private const int IncreaseValue = 1; // Why +1 ?  because Always Array's start element index 0 and +1 for -1 when do End-Start 

        public int StartRow { get; } = 0;

        public int StartColumn { get; } = 0;

        public int MatrixRowCount => _endRow - StartRow + IncreaseValue;

        public int MatrixColumnCount => _endColumn - StartColumn + IncreaseValue;

        private int IRow { get; set; }
        private int JColumn { get; set; }

        private object[,] _matrix = null;

        private bool _transaction = false;

        public Matrix(int startRow, int endRow, int startColumn, int endColumn)
        {
            this.StartRow = startRow;
            this._endRow = endRow;
            this.StartColumn = startColumn;
            this._endColumn = endColumn;
        }

        public IEnumerable<int[]> GetIndexOfMatrix()
        {
            this._matrix = new object[MatrixRowCount + IncreaseValue, MatrixColumnCount + IncreaseValue];
            _transaction = true;

            for (var i = StartRow; i <= _endRow; i++)
            {
                for (var j = StartColumn; j <= _endColumn; j++)
                {
                    IRow = i;
                    JColumn = j;
                    yield return new[] { i, j };
                }
            }

            _transaction = false;
        }

        public void SetValue(object value)
        {
            if (_matrix != null)
                this._matrix[IRow - StartRow, JColumn - StartColumn + 1] = value;
        }

        public object[,] GetMatrix()
        {
            return _transaction ? null : _matrix;
        }

        public object[,] GetMatrix(object[,] matrixData) // GetNewMatrix inside from Matrix
        {// This method not use
            foreach (var item in GetIndexOfMatrix())
            {
                var value = matrixData[item[0], item[1]];
                //matrix.SetValue(value);
            }

            return GetMatrix();
        }
    }
}
