using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IassetTechnicalTest.Api.Models
{
    public class BriefWeatherDetails
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyConditions { get; set; }
        public string Temperature { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }

        public BriefWeatherDetails(RootObject fullRootObject)
        {
            this.Location = fullRootObject.coord.GeoCoords;
            this.Time = fullRootObject.RequestTime;
            this.Wind = string.Format("Wind speed.Unit {0} meter / sec", fullRootObject.wind.speed.ToString("N1"));
            this.Visibility = fullRootObject.visibility.ToString();
            this.Pressure = string.Format("{0} hPa", fullRootObject.main.pressure);  
            this.SkyConditions = string.Format("Cloudiness,{0} %", fullRootObject.clouds.all);
            this.Temperature = string.Format(" Temperature.Unit {0} Kelvin", fullRootObject.main.temp.ToString("N1"));
            this.RelativeHumidity= string.Format("Humidity,{0} %", fullRootObject.main.humidity.ToString("N1"));

        }
    }
}