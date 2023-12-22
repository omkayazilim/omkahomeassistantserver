
using Domain.Dto;

namespace Domain.Interface
{
    public interface IEspPortDefService
    {
        Task Create(EspPortDefCreateRequestDto entity);
        Task Update(EspPortDefUpdateRequestDto entity);
        Task Delete(long id);
        Task<List<EspPortDefListItemDto>> Get();
        Task<EspPortDefListItemDto> Get(long Id);


    }
}
