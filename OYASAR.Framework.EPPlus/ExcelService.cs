using System.Linq;

namespace OYASAR.Framework.EPPlus
{
    public class ExcelService
    {
        private readonly string _path;

        public ExcelService(string filePath)
        {
            _path = filePath;
        }

        public string[] GetData()
        {
            var excelReader = new ExcelReader(_path);

            var result = excelReader.ReadExcel(1);

            return result.Cast<string>().ToArray();
        }


        //private T GetAll<T>()
        //{
        //    var data = GetData();

        //    var fieldCount = typeof(T).

        //    int i = 0;

        //    var result = data.GroupBy(x => Math.Floor(i++ / 5.0))
        //                .Select(g => new { CityName = g.ElementAt(1), CityCode = g.ElementAt(2), DistrictName = g.ElementAt(3), ZipCode = g.ElementAt(4) });


        //    //var result = data.GroupBy(x => Math.Floor(i++ / 5.0))
        //    //            .Select(g => new { CityName = g.ElementAt(1), CityCode = g.ElementAt(2), DistrictName = g.ElementAt(3), ZipCode = g.ElementAt(4) })
        //    //            .GroupBy(x => new { x.CityName, x.CityCode }, x => new District { DistrictName = x.DistrictName, Zip = new Zip { Code = x.ZipCode } })
        //    //            .Where(h => h.Key.CityName != null)
        //    //            .Select(y => new City { CityName = y.Key.CityName.Replace("\n", ""), CityCode = y.Key.CityCode, Districts = y.OrderBy(z => z.DistrictName).ToList() })
        //    //            .OrderBy(h => h.CityName);


        //    return result;
        //}
    }
}
