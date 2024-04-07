using CsvHelper.Configuration;

namespace ConsoleApp1
{
    public class ConsumoComarcaMap : ClassMap<ConsumoComarca>
    {
        public ConsumoComarcaMap()
        {
            Map(p => p.Any).Index(0);
            Map(p => p.CodiComarca).Index(1);
            Map(p => p.Comarca).Index(2);
            Map(p => p.Poblacio).Index(3);
            Map(p => p.DomesticXarxa).Index(4);
            Map(p => p.ActivitatsEconomiques).Index(5);
            Map(p => p.Total).Index(6);
            Map(p => p.ConsumDomésticPerCapita).Index(7);
        }
    }
}
