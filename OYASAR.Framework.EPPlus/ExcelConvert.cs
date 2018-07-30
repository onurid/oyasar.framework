using OfficeOpenXml;
using System.IO;

namespace OYASAR.Framework.EPPlus
{
    public class ExcelConvert
    {
        public ExcelPackage ConvertCsvToExcel(FileInfo csvFileInfo)
        {
            const string worksheetsName = "TEST";

            var excelTextFormat = new ExcelTextFormat
            {
                Delimiter = ',',
                EOL = "\r"
            };

            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add(worksheetsName);
            worksheet.Cells["A1"].LoadFromText(csvFileInfo, excelTextFormat, OfficeOpenXml.Table.TableStyles.Medium25, false);
            package.Save();

            return package;

        }
    }
}
