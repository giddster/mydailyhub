using MyDailyHub.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyDailyHub.Services
{
    public class NewsService
    {
        public NewsModel NewsModel { get; set; }
        public string Country { get; set; }

        /// <summary>
        /// Sets the Country value from IP
        /// </summary>
        /// <param name="country"></param>
        public NewsService(string country)
        {
            Country = country;
        }

        /// <summary>
        /// Calls NewsAPI and returns a model of current headlines for the user's country
        /// </summary>
        /// <returns> List of articles </returns>
        public NewsModel GetNewsModel()
        {
            var apiKey = "737834b173e4495ab27e43547318c69d";
            using (WebClient wc = new WebClient())
            {
                string jsonString = wc.DownloadString(new Uri($"https://newsapi.org/v2/top-headlines?country={Country}&apiKey={apiKey}"));
                NewsModel = JsonConvert.DeserializeObject<NewsModel>(jsonString);
            }

            return NewsModel;
        }
    }
}
