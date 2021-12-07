namespace CRT_WebApp.Shared
{
    public class AssemblyItemModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Rate { get; set; }
        public string Metric { get; set; }
        public double NumberOfUnits { get; set; }
        public double Total { get; set; }


        public string GetFormattedTotalPrice() => Total.ToString("0.00");
        public string GetFormattedRate() => Rate.ToString("0.00");
        public string NumberOfUnitsWithMetric() => NumberOfUnits + " " + Metric;
    }
}
