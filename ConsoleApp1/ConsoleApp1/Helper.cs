using CsvHelper;
using System.Globalization;

namespace ConsoleApp1
{
    public static class Helper
    {
        public static List<ConsumoComarca> ConvertCsvToList(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ConsumoComarca>();
            return records.ToList();
        }
    }
}
