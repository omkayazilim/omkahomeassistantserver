using Domain.Dto;
using Domain.Interface;
using Infrastructer;
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
            var resp = _esp8266.PostPinStat(stat);
            return resp;
        }


        [HttpGet]
        public string getpath()
        {
            _logger.LogInformation("Start call");
            var resp = _esp8266.getpath();
            return resp;
        }

        [HttpGet]
        public async Task<List<PortPropsDto>> GetPortProps()
        {
            _logger.LogInformation("Start call");
            var resp = await _esp8266.GetPortProps();
            return resp;
        }

        [HttpPut]
        public async Task NewPortProps([FromBody]PortPropsSetRequestDto request)
        {
            _logger.LogInformation("Start call");
            await _esp8266.NewPortProp(request);
        }

        [HttpPost]
        public async Task UpdatePortProps([FromBody] PortPropsSetRequestDto request)
        {
            _logger.LogInformation("Start call");
            await _esp8266.UpdatePortProp(request);
        }

        [HttpDelete]
        public async Task DeletePortProps(long Id)
        {
            _logger.LogInformation("Start call");
            await _esp8266.DeletePortProp(Id);
        }


    }
}
