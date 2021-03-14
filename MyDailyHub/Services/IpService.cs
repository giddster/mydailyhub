using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using MyDailyHub.Controllers;
using System.Net.Http;
using MyDailyHub.Models;

namespace MyDailyHub.Services
{
    public class IpService
    {

        public string ip_String { get; set; }
        
        public IpService(string ip)
        {
            ip_String = ip;
        }

        public IpModel GetIpInfo()
        {
            IpModel ipInfo = null;
            var apiKey = "5e40b6754ec2df29eb892f39aa57a1ec";
            var url = $"http://api.ipstack.com/{ip_String}?access_key={apiKey}";

            using (var client = new HttpClient())
            {
                var t = client.GetAsync(url);
                var response = t.GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var readResponse = response.Content.ReadAsStringAsync();
                    var readResponseResult = readResponse.GetAwaiter().GetResult();

                    ipInfo = JsonSerializer.Deserialize<IpModel>(readResponseResult);
                }
            }
            
            return ipInfo;
        }
    }

}
