using Domain.Dto;

namespace Domain.Interface
{
    public interface IDeviceDefService
    {
        Task<List<DeviceDefDto>> Get();
        Task<DeviceDefDto> Get(long Id);
        Task Update(DeviceDefRequestDto entity);
        Task Delete(long Id);
        Task Create(DeviceDefRequestDto entity);
    }
}
