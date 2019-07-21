
namespace Telefrek.OpenRTB.Entities
{
    /// <summary>
    /// An OpenRTB metric object
    /// </summary>
    public class Metric
    {
        /// <summary>
        /// The type of metric
        /// </summary>
        /// <value></value>
        
        public string MetricType { get; set; }

        /// <summary>
        /// The value of the metric
        /// </summary>
        /// <value></value>
        
        public double Value { get; set; }

        /// <summary>
        /// The vendor providing the metric
        /// </summary>
        /// <value></value>
        
        public string Vendor { get; set; }
    }
}