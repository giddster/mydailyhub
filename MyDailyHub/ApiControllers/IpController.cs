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
    public class IpController : ControllerBase
    {

        //public string Get()
        //{
        //    IpService ipService = null;
        //    var remoteIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();

        //    if (remoteIp != "127.0.0.1")
        //    {
        //        ipService = new IpService(remoteIp);
        //    }
        //    else
        //    {
        //        remoteIp = "142.251.33.78"; //google lol
        //        ipService = new IpService(remoteIp);
        //    }

        //    return remoteIp;
        //}

    }
}
