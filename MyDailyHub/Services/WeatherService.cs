using MyDailyHub.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyDailyHub.Services
{
    public class WeatherService
    {
        public WeatherModel WeatherModel { get; set; }
        public string City { get; set; }
        
        /// <summary>
        /// Sets the City property so that WeatherModel can be created
        /// </summary>
        /// <param name="city"></param>
        public WeatherService(string city)
        {
            City = city;
        }

        /// <summary>
        /// Calls the OpenWeather API and returns a WeatherModel
        /// </summary>
        /// <returns>WeatherModel based on IP</returns>
        public WeatherModel GetWeatherModel()
        {
            
            var apiKey = "dd36506305d949074912c78dff8c3bf8";
            using (WebClient wc = new WebClient())
            {
                string jsonString = wc.DownloadString(new Uri($"https://api.openweathermap.org/data/2.5/weather?q={City}&appid={apiKey}"));

                WeatherModel = JsonConvert.DeserializeObject<WeatherModel>(jsonString);
            }

            return WeatherModel;
        }
    }
}
