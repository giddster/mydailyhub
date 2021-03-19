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
using Newtonsoft.Json;

namespace MyDailyHub.Services
{
    /// <summary>
    /// Collects the user's IP address and then uses the IPstack API to get additional location info
    /// </summary>
    public class IpService
    {
        public IpModel IpModel { get; set; }
        public HttpRequest Request { get; }
        public string ip_String { get; set; }

        /// <summary>
        /// Gets request from HomeController
        /// </summary>
        /// <param name="request"></param>
        public IpService(HttpRequest request)
        {
            Request = request;
            ip_String = GetIpAddress();
        }

        /// <summary>
        /// Returns remote IP or placeholder if remote IP is null/localhost
        /// </summary>
        /// <returns> usable IP address </returns>
        public string GetIpAddress()
        {
            var remoteIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            if (remoteIp != "127.0.0.1")
            {
                return remoteIp;
            }
            else
            {
                remoteIp = "81.233.4.247";
            }

            return remoteIp;
        }

        /// <summary>
        /// calls ipstack API to get location info on user's IP address
        /// </summary>
        public IpModel GetIpModel()
        {
            var apiKey = "5e40b6754ec2df29eb892f39aa57a1ec";

            using (WebClient wc = new WebClient())
            {
                string jsonString = wc.DownloadString(new Uri($"http://api.ipstack.com/{ip_String}?access_key={apiKey}")); 

                IpModel = JsonConvert.DeserializeObject<IpModel>(jsonString);
            }
            
            return IpModel;
        }
              
        
    }

}
