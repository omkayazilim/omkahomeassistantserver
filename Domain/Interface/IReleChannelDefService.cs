

using Domain.Dto;

namespace Domain.Interface
{
    public interface IReleChannelDefService
    {
        Task Create(ReleChannelCreateRequestDto entity);
        Task Update(ReleChannelCreateRequestDto entity);
        Task Delete(long id);
        Task<List<ReleChannelListItemDto>> Get();
        Task<ReleChannelListItemDto> Get(long Id);
    }
}
