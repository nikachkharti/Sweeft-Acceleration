using System.Diagnostics.Metrics;

namespace Countries.Library
{
    public class Country
    {
        public Name Name { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public List<double> Latlng { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }

        public override string ToString()
        {
            return $"Region : {Region}\nSubRegion : {SubRegion}\nLatitude : {string.Join(",", Latlng)}\nArea : {Area}\nPopulation : {Population}";
        }
    }
}
