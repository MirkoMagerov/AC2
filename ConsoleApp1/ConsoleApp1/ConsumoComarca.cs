using CsvHelper.Configuration.Attributes;
using LINQtoCSV;

namespace ConsoleApp1
{
    public class ConsumoComarca
    {
        private const int LitersToM3 = 1000;

        [CsvColumn(Name = "Any")]
        public int Any { get; set; }

        [Name("Codi comarca")]
        public int CodiComarca { get; set; }

        [Name("Comarca")]
        public string Comarca { get; set; }

        [Name("Població")]
        public int Poblacio { get; set; }

        [Name("Domèstic xarxa")]
        public int DomesticXarxa { get; set; }

        [Name("Activitats econòmiques i fonts pròpies")]
        public int ActivitatsEconomiques { get; set; }

        [Name("Total")]
        public int Total { get; set; }

        [Name("Consum domèstic per càpita")]
        public double ConsumDomésticPerCapita { get; set; }

        public ConsumoComarca(int any, int codiComarca, string comarca, int poblacio, int domesticXarxa, int activitatsEconomiques, int total, double consumDomésticPerCapita)
        {
            Any = any;
            CodiComarca = codiComarca;
            Comarca = comarca;
            Poblacio = poblacio;
            DomesticXarxa = domesticXarxa;
            ActivitatsEconomiques = activitatsEconomiques;
            Total = total;
            ConsumDomésticPerCapita = consumDomésticPerCapita / LitersToM3;
        }

        public override string ToString()
        {
            return $"Any: {Any}, CodiComarca: {CodiComarca}, Comarca: {Comarca}, " +
                   $"Poblacio: {Poblacio}, DomesticXarxa (M³): {DomesticXarxa}, " +
                   $"ActivitatsEconomiques (M³): {ActivitatsEconomiques}, Total (M³): {Total}, " +
                   $"ConsumDomésticPerCapita (M³): {ConsumDomésticPerCapita}";
        }
    }
}
