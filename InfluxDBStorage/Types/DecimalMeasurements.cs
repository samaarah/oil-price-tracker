using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDBStorage.Interfaces;

namespace InfluxDBStorage.Types
{
    public class DecimalMeasurements : IInfluxMetrics
    {
        Dictionary<string, object> Measurements;

        public DecimalMeasurements()
        {
            Measurements = new Dictionary<string, object>();
        }

        public void AddMeasurement(string measurementName, object measurementValue)
        {
            Measurements.Add(measurementName, measurementValue);
        }

        public Dictionary<string, object> GetMeasurements()
        {
            return Measurements;
        }
    }
}
