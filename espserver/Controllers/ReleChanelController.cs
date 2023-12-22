using Domain.Dto;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReleChanelController : ControllerBase
    {
        private readonly IReleChannelDefService _service;
        public ReleChanelController(IReleChannelDefService service)
        {
            _service = service;
        }
        [HttpPut]
        public Task Create(ReleChannelCreateRequestDto entity) => _service.Create(entity);
        [HttpPost]
        public Task Update(ReleChannelCreateRequestDto entity) => _service.Update(entity);
        [HttpDelete]
        public Task Delete(long id) =>  _service.Delete(id);
        [HttpGet]
        public async Task<List<ReleChannelListItemDto>> Get() => await _service.Get();
        [HttpGet("GetById")]
        public async Task<ReleChannelListItemDto> Get(long Id)=> await _service.Get(Id);

    }
}
