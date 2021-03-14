using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDailyHub.Models
{
    public class QuoteModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<QuoteModel>(myJsonResponse); 
        public string Text { get; set; }
        public string Author { get; set; }
    }
}
