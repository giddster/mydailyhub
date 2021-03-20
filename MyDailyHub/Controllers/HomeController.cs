using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDailyHub.Models;
using MyDailyHub.Models.ViewModels.Home;
using MyDailyHub.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyDailyHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IpService ipService = new IpService(Request);

            QuotesService quotesService = new QuotesService();

            WeatherService weatherService = new WeatherService(ipService.IpModel.city);

            NewsService newsService = new NewsService(ipService.IpModel.country_code);

            IndexViewModel indexViewModel = new IndexViewModel(quotesService.GetRandomQuoteModel(), weatherService.GetWeatherModel(), newsService.GetNewsModel());
            return View(indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
