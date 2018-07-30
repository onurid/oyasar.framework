using System;
using System.IO;
using OfficeOpenXml;
using OYASAR.Framework.Core.Utils;

namespace OYASAR.Framework.EPPlus
{
    public class ExcelReader : IDisposable
    {
        private readonly ExcelPackage _package;

        public ExcelReader(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception("File Not Found!");

            _package = new ExcelPackage(new FileInfo(filePath));
        }

        public object[,] ReadExcel(int worksheetNumber)
        {
            var workSheet = _package.Workbook.Worksheets[worksheetNumber];

            var matrix = new Matrix(workSheet.Dimension.Start.Row, workSheet.Dimension.End.Row,
                workSheet.Dimension.Start.Column, workSheet.Dimension.End.Column);

            return FillMatrixFromWorksheet(matrix, workSheet);
        }

        public object[,] ReadExcel(int worksheetNumber, Matrix matrix)
        {
            var worksheet = _package.Workbook.Worksheets[worksheetNumber];

            return FillMatrixFromWorksheet(matrix, worksheet);
        }

        public object[,] FillMatrixFromWorksheet(Matrix matrix, ExcelWorksheet worksheet)
        {
            foreach (var item in matrix.GetIndexOfMatrix())
            {
                var value = worksheet.Cells[item[0], item[1]].Value?.ToString();
                matrix.SetValue(value);
            }

            return matrix.GetMatrix();
        }

        public void Dispose()
        {
            _package.Dispose();
        }
    }
}
