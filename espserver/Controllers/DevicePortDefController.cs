using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DevicePortDefController : ControllerBase
    {
        private readonly IDevicePortDefService _service;
        public DevicePortDefController(IDevicePortDefService deviceDefService)
        {
            _service = deviceDefService;
        }
        [HttpPut]
        public async Task Create([FromBody] DevicePortDefRequestDto entity) => await _service.Create(entity);
        [HttpPost]
        public async Task Update([FromBody] DevicePortDefRequestDto entity) => await _service.Update(entity);
        [HttpDelete]
        public async Task Delete(long id) => await _service.Delete(id);
        [HttpGet]
        public async Task<List<DevicePortDefDto>> Get() => await _service.Get();
        [HttpGet("GetById")]
        public async Task<DevicePortDefDto> Get(long id) => await _service.Get(id);
    }
}
