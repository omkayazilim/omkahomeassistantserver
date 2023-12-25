using Domain.Dto;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace espserver.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EspPortDefController : ControllerBase
    {
        private readonly IEspPortDefService _service;
        public EspPortDefController(IEspPortDefService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task Create([FromBody]EspPortDefCreateRequestDto entity)  => await _service.Create(entity);
        [HttpPost]
        public async Task Update([FromBody] EspPortDefUpdateRequestDto entity) => await _service.Update(entity);

        [HttpDelete]
        public async Task Delete(long id) =>await  _service.Delete(id);

        [HttpGet]
        public async Task<List<EspPortDefListItemDto>> Get()=>await _service.Get();

        [HttpGet("GetById")]
        public async Task<EspPortDefListItemDto> Get(long id) => await _service.Get(id);
    }
}
