using Domain.Dto;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChannelOperationController : ControllerBase
    {
        private readonly IChannelOperationService _service;
        public ChannelOperationController(IChannelOperationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<PingResponseDto>> GetDeviceStatus() => await _service.GetDeviceStatus();  
        
        [HttpGet]
        public async Task<ChannelStatResponseDto> GetChannelStat(long ChannelId) => await _service.GetChannelStat(ChannelId);

        [HttpGet]
        public async Task SetChanelStatus(long channelId, bool stat) => await _service.ChangeStatusChannel(channelId,stat);
    }
}
