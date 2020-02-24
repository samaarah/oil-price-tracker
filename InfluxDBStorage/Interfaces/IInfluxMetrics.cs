using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluxDBStorage.Interfaces
{
    public interface IInfluxMetrics
    {
        void AddMeasurement(string measurementName, object measurementValue);

        Dictionary<string, object> GetMeasurements();
    }
}
