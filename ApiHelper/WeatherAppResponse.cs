using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChecker.BDD.ApiHelper
{
    public class Currently
    {
        public int time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public int nearestStormDistance { get; set; }
        public int nearestStormBearing { get; set; }
        public int precipIntensity { get; set; }
        public int precipProbability { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float humidity { get; set; }
        public int pressure { get; set; }
        public float windSpeed { get; set; }
        public float windGust { get; set; }
        public int windBearing { get; set; }
        public float cloudCover { get; set; }
        public int uvIndex { get; set; }
        public int visibility { get; set; }
        public float ozone { get; set; }
    }

    public class WeatherAppResponse
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string timezone { get; set; }
        public Currently currently { get; set; }
        public int offset { get; set; }
    }


    public class Error
    {
        public string errorMessage { get; set; }
    }


}
