using Microsoft.AspNetCore.Http;
using MyDailyHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDailyHub.Models.ViewModels.Home
{
    public class IndexViewModel
    {
        public IpModel MyProperty { get; set; }
        public QuoteModel QuoteModel { get; set; }
        public WeatherModel WeatherModel { get; set; }
        public NewsModel NewsModel { get; set; }

        public IndexViewModel(QuoteModel quotes, WeatherModel weather, NewsModel news)
        {
            QuoteModel = quotes;
            WeatherModel = weather;
            NewsModel = news;
        }

    }
}
