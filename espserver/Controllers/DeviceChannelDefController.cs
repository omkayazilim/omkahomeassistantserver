using Domain.Dto;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeviceChannelDefController : ControllerBase
    {
        private readonly IDeviceChannelDefService _service;
        public DeviceChannelDefController(IDeviceChannelDefService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task Create([FromBody] DeviceChannelDefRequestDto entity) => await _service.Create(entity);
        [HttpPost]
        public async Task Update([FromBody] DeviceChannelDefRequestDto entity) => await _service.Update(entity);
        [HttpDelete]
        public async Task Delete(long id) => await _service.Delete(id);
        [HttpGet]
        public async Task<List<DeviceChannelDefDto>> Get() => await _service.Get();
        [HttpGet("GetById")]
        public async Task<DeviceChannelDefDto> Get(long id) => await _service.Get(id);
    }
}
