namespace ConsoleApp1
{
    public class ConsumoComarca
    {
        private const int LitersToM3 = 1000;

        public int Any { get; set; }

        public int CodiComarca { get; set; }

        public string Comarca { get; set; }

        public int Poblacio { get; set; }

        public int DomesticXarxa { get; set; }

        public int ActivitatsEconomiques { get; set; }

        public int Total { get; set; }

        public double ConsumDomésticPerCapita { get; set; }

        public ConsumoComarca()
        {

        }

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
                   $"Poblacio: {Poblacio}, DomèsticXarxa (M³): {DomesticXarxa}, " +
                   $"ActivitatsEconòmiques (M³): {ActivitatsEconomiques}, Total (M³): {Total}, " +
                   $"ConsumDomésticPerCèpita (M³): {ConsumDomésticPerCapita}";
        }
    }
}
