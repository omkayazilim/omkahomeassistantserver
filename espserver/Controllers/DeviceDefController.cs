using Domain.Dto;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeviceDefController : ControllerBase
    {
        private readonly IDeviceDefService _service;
        public DeviceDefController(IDeviceDefService deviceDefService)
        {
                _service = deviceDefService;   
        }
        [HttpPut]
        public async Task Create([FromBody] DeviceDefRequestDto entity) => await _service.Create(entity);
        [HttpPost]
        public async Task Update([FromBody] DeviceDefRequestDto entity) => await _service.Update(entity);
        [HttpDelete]
        public async Task Delete(long id) => await _service.Delete(id);
        [HttpGet]
        public async Task<List<DeviceDefDto>> Get() => await _service.Get();
        [HttpGet("GetById")]
        public async Task<DeviceDefDto> Get(long id) => await _service.Get(id);


    }
}
