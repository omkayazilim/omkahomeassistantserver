
using Domain.Dto;

namespace Domain.Interface
{
    public interface IDeviceChannelDefService
    {
        Task<List<DeviceChannelDefDto>> Get();
        Task<DeviceChannelDefDto> Get(long Id);
        Task Update(DeviceChannelDefRequestDto entity);
        Task Delete(long Id);
        Task Create(DeviceChannelDefRequestDto entity);
    }
}
