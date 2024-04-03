namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            const string CsvPath = @"..\..\..\Ficheros\Consumo_de_agua.csv";

            List<ConsumoComarca> consumoComarcas = Helper.ConvertCsvToList(CsvPath);

            foreach(ConsumoComarca consumoComarca in consumoComarcas)
            {
                Console.WriteLine(consumoComarca.ToString());
            }
        }
    }
}