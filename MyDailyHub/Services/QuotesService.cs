using MyDailyHub.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyDailyHub.Services
{
    public class QuotesService
    {
        public List<QuoteModel> QuotesList { get; set; }
        public string JsonQuotesString { get; set; }


        public QuotesService()
        {
            using (WebClient wc = new WebClient())
            {
                string jsonString = wc.DownloadString(new Uri("https://type.fit/api/quotes")); //Fråga Robert varför MS egna Deserializer inte kan deserialajsa utan returnerar en lista med nulls

                QuotesList = JsonConvert.DeserializeObject<List<QuoteModel>>(jsonString);
            }
        }

        public QuoteModel GetRandomQuoteModel()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, QuotesList.Count - 1);
            return QuotesList[randomIndex];
        }
    }
}
