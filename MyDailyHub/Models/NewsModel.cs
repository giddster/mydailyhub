using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDailyHub.Models
{
    public class NewsModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
        
        public class Source
        {
            public string id { get; set; }
            public string name { get; set; } //use
        }

        public class Article
        {
            public Source source { get; set; }
            public string author { get; set; }
            public string title { get; set; } //use
            public string description { get; set; }
            public string url { get; set; }
            public string urlToImage { get; set; } //use
            public DateTime publishedAt { get; set; }
            public string content { get; set; }
        }

    }
}
