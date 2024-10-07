using Domain.Dto;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EspController : ControllerBase
    {
        private readonly IEsp8266Service _esp8266;
        private readonly ILogger<EspController> _logger;
        public EspController(IEsp8266Service espset, ILogger<EspController> logger)
        {
            _esp8266 = espset;
            _logger = logger;
        }
        [HttpPost]
        public List<PortStatResponse> EspSetValue([FromBody] PortStatDto stat)
        {
            _logger.LogInformation("Start call");
            var resp = _esp8266.PostPinStat(stat, "http://192.168.1.12");
            return resp;
        }
    }
}
