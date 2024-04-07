using CsvHelper;
using System.Globalization;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public static class Helper
    {
        public static List<ConsumoComarca> ConvertCsvToList(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ConsumoComarcaMap>();
                var records = csv.GetRecords<ConsumoComarca>();

                return records.ToList();
            }
        }

        public static void SerializeToXml<T>(List<T> list, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, list);
            }
        }

        public static List<ConsumoComarca> ConvertXMLToList(string path)
        {
            List<ConsumoComarca> list = new List<ConsumoComarca>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ConsumoComarca>));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                list = (List<ConsumoComarca>)serializer.Deserialize(fileStream);
            }

            return list;
        }

        public static void PoblacionSuperior200000(string path)
        {
            List<ConsumoComarca> lista = ConvertXMLToList(path);

            Console.WriteLine("Comarcas con una población superior a 200.000:");
            foreach (ConsumoComarca comarca in lista)
            {
                if (comarca.Poblacio > 200000)
                {
                    Console.WriteLine($"Comarca: {comarca.Comarca}, Población: {comarca.Poblacio}.");
                    Console.WriteLine();
                }
            }
        }

        public static void MediaConsumoDomestico(string path)
        {
            List<ConsumoComarca> lista = ConvertXMLToList(path);

            Console.WriteLine("Consumo doméstico medio por comarca:");
            foreach(ConsumoComarca comarca in lista)
            {
                double consumoMedio = Math.Round((double)comarca.Poblacio / comarca.DomesticXarxa * 1000, 2);
                Console.WriteLine($"Comarca: {comarca.Comarca}, Media consumo doméstico: {consumoMedio}.");
                Console.WriteLine();
            }
        }

        public static void ComarcasConConsumoPerCapitaMasAlto(string path, int numberOfComarcas)
        {
            if (numberOfComarcas < 1 )
            {
                Console.WriteLine("Debes elegir por lo menos 1 comarca a mostrar.");
                return;
            }

            List<ConsumoComarca> lista = ConvertXMLToList(path);

            Console.WriteLine("Comarcas con una población superior a 200.000:");

            List<ConsumoComarca> consumoCapitaAlto = lista.OrderByDescending(e => e.ConsumDomésticPerCapita).ToList();

            Console.WriteLine($"Lista de las {numberOfComarcas} comarcas con el consumo doméstico por cápita más alto:");
            for (int i = 0; i < numberOfComarcas; i++)
            {
                Console.WriteLine(consumoCapitaAlto[i]);
                Console.WriteLine();
            }
        }

        public static void ComarcasConConsumoPerCapitaMasBajo(string path, int numberOfComarcas)
        {
            if (numberOfComarcas < 1)
            {
                Console.WriteLine("Debes elegir por lo menos 1 comarca a mostrar.");
                return;
            }

            List<ConsumoComarca> lista = ConvertXMLToList(path);

            Console.WriteLine("Comarcas con una población superior a 200.000:");

            List<ConsumoComarca> consumoCapitaAlto = lista.OrderBy(e => e.ConsumDomésticPerCapita).ToList();

            Console.WriteLine($"Lista de las {numberOfComarcas} comarcas con el consumo doméstico por cápita más bajo:");
            for (int i = 0; i < numberOfComarcas; i++)
            {
                Console.WriteLine(consumoCapitaAlto[i]);
                Console.WriteLine();
            }
        }

        public static ConsumoComarca FiltrarNombreOCodigo(string path, string param = "")
        {
            List<ConsumoComarca> lista = ConvertXMLToList(path);

            if (int.TryParse(param, out int codigo))
            {
                ConsumoComarca consumo = lista.Find(x => x.CodiComarca == codigo);

                if (consumo != null) return consumo;
                else
                {
                    Console.WriteLine("No existe ninguna comarca con ese código.");
                    return null;
                }
            }
            else
            {
                ConsumoComarca consumo = lista.Find(x => x.Comarca == param);
                if (consumo != null) return consumo;

                else
                {
                    Console.WriteLine("No existe ninguna comarca con ese nombre.");
                    return null;
                }
            }
        }
    }
}
