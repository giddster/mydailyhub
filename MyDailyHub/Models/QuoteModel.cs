using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDailyHub.Models
{
    public class QuoteModel
    {
        public string Text { get; set; }
        public string Author { get; set; }
    }

    public class Quotes
    {
        public List<QuoteModel> quotesList { get; set; }
    }
}
