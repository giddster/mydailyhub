using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDailyHub.Models;
using MyDailyHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDailyHub.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        [HttpGet]
        public QuoteModel Get()
        {
            QuotesService quotesService = new QuotesService();
            var quoteModel = quotesService.GetRandomQuoteModel();
            return quoteModel;
        }
    }
}
// NB: this is unnecessary in terms of displaying a random quote on the view. However, this ensures that the API can be used by others