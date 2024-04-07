namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string XmlPath = @"..\..\..\Ficheros\Consumo_de_agua.xml";
            const string CsvPath = @"..\..\..\Ficheros\Consumo_de_agua.csv";

            const string MenuMessage = "Seleccione una opción:";
            const string Option1Message = "1. Población superior a 200,000.";
            const string Option2Message = "2. Media de consumo doméstico.";
            const string Option3Message = "3. Comarcas con consumo per cápita más alto.";
            const string Option4Message = "4. Comarcas con consumo per cápita más bajo.";
            const string Option5Message = "5. Filtrar por nombre o código.";
            const string Option6Message = "6. Salir.";
            const string OptionPrompt = "Opción: ";

            const string InvalidOptionMessage = "Opción no válida. Inténtelo de nuevo.";
            const string EnterQuantityMessage = "Ingrese la cantidad de comarcas a mostrar: ";
            const string EnterNameCodeMessage = "Ingrese el nombre o código de la comarca: ";
            const string ExitMessage = "Saliendo del programa...";

            // Crear el archivo XML
            Helper.SerializeToXml(Helper.ConvertCsvToList(CsvPath), XmlPath);

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine(MenuMessage);
                Console.WriteLine(Option1Message);
                Console.WriteLine(Option2Message);
                Console.WriteLine(Option3Message);
                Console.WriteLine(Option4Message);
                Console.WriteLine(Option5Message);
                Console.WriteLine(Option6Message);

                Console.Write(OptionPrompt);

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Helper.PoblacionSuperior200000(XmlPath);
                        break;

                    case "2":
                        Helper.MediaConsumoDomestico(XmlPath);
                        break;

                    case "3":
                        Console.Write(EnterQuantityMessage);
                        try
                        {
                            int cantidadAlto = int.Parse(Console.ReadLine());
                            Helper.ComarcasConConsumoPerCapitaMasAlto(XmlPath, cantidadAlto);
                        }
                        catch
                        {
                            Console.WriteLine(InvalidOptionMessage);
                        }
                        break;

                    case "4":
                        Console.Write(EnterQuantityMessage);
                        try
                        {
                            int cantidadBajo = int.Parse(Console.ReadLine());
                            Helper.ComarcasConConsumoPerCapitaMasBajo(XmlPath, cantidadBajo);
                        }
                        catch
                        {
                            Console.WriteLine(InvalidOptionMessage);
                        }
                        break;

                    case "5":
                        Console.Write(EnterNameCodeMessage);
                        try
                        {
                            string nombreCodigo = Console.ReadLine();
                            Console.WriteLine(Helper.FiltrarNombreOCodigo(XmlPath, nombreCodigo).ToString());
                        }
                        catch
                        {
                            Console.WriteLine(InvalidOptionMessage);
                        }
                        break;

                    case "6":
                        continuar = false;
                        Console.WriteLine(ExitMessage);
                        break;

                    default:
                        Console.WriteLine(InvalidOptionMessage);
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}