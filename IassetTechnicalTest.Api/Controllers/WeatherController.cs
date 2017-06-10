using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.XPath;
using IassetTechnicalTest.Api.Helper;
using IassetTechnicalTest.Api.Models;


namespace IassetTechnicalTest.Api.Controllers
{
    public class WeatherController : ApiController
    {
        private string _apiKey = "1ea3170e01ba7e0c73273f840d7c8085";
        /// <summary>
        /// provides us a list of cities belong to specified country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/cities")]
        public async Task<List<string>> CitiesAsync(string country)
        {
            var result = new List<string>();
           globalweather.GlobalWeatherSoapClient weather = new globalweather.GlobalWeatherSoapClient();
            var cities= await weather.GetCitiesByCountryAsync(country);

            var doc = XDocument.Parse(cities);
            var cityList = doc.XPathSelectElements("NewDataSet/Table/City");
            var cityListEnumerator = cityList.GetEnumerator();
            while (cityListEnumerator.MoveNext())
            {
                result.Add(cityListEnumerator.Current.Value);
            }
          return result;
        }
        /// <summary>
        /// provide us a current weather of the specified city of the country
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="countryName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/weather/Current")]
        public async Task<BriefWeatherDetails> Current(string cityName,string countryName)
        {
            // globalweather service didn’t return any data after multiple try I used alternative api instead.
            string url = string.Format("weather?q={0},{1}&appid={2}", cityName, countryName, _apiKey);
            var weatherDetails = await WebServiceHelper.GetWsObject<RootObject>("http://api.openweathermap.org/data/2.5/", url);
            var weatherCustomFormat = new BriefWeatherDetails(weatherDetails);
            return weatherCustomFormat;
        }

    }
}
