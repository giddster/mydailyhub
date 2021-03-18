using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDailyHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyDailyHub.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        public string Get()
        {
            IpService ipService = null;
            var remoteIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            if (remoteIp != "127.0.0.1")
            {
                ipService = new IpService(remoteIp);
            }
            else
            {
                string placeHolderIp = "81.233.4.247";
                ipService = new IpService(placeHolderIp);
            }

            return ipService.GetIpInfo().city;
        }

    }
}
