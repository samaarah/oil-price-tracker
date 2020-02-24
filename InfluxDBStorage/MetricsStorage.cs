using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Net;
using InfluxDB.Net.Enums;
using InfluxDB.Net.Infrastructure.Influx;
using InfluxDB.Net.Models;
using InfluxDBStorage.Interfaces;

namespace InfluxDBStorage
{
    public class MetricsStorage
    {
        private string InfluxDbUrl;

        private string UserName;

        private string Password;

        public MetricsStorage(string url, string userName, string password)
        {
            InfluxDbUrl = url;
            UserName = userName;
            Password = password;
        }

        public async void SaveMetricsToInflux(string databaseName, string measurementName, IInfluxMetrics metrics)
        {
            await Task.Run(async () =>
            {
                InfluxDb client = new InfluxDb(InfluxDbUrl, UserName, Password);
                Point point = new Point();
                Dictionary<string, object> dict = new Dictionary<string, object>();

                foreach(var measurement in metrics.GetMeasurements())
                {
                    dict.Add(measurement.Key, measurement.Value);
                }
                
                point.Measurement = measurementName;
                point.Fields = dict;

                InfluxDbApiResponse writeResponse = await client.WriteAsync(databaseName, point);
            });
        }
    }
}
