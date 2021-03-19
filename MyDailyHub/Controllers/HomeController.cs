using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDailyHub.Models;
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
            //QuotesService quotes = new QuotesService();
            //return View(quotes.GetRandomQuoteModel());

            IpService ipService = new IpService(Request);
            ipService.GetIpModel();

            WeatherService weatherService = new WeatherService(ipService.IpModel.city);
            return View(weatherService.GetWeatherModel());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
