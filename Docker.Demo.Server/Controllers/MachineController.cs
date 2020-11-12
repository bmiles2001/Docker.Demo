using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Docker.Demo.Server.Controllers
{
    [Route("[controller]/[action]")]
    public class MachineController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetComputerInfo()
        {
            MachineInfo info = new MachineInfo
            {
                Hostname = Dns.GetHostName(),
                LocalIP = HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString() // could be ipv4 or ipv6
            };

            return Ok(info);
        }
    }

    public class MachineInfo
    {
        public string Hostname { get; set; }
        public string LocalIP { get; set; }
    }
}