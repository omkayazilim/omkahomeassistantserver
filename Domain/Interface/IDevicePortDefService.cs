using Domain.Dto;

namespace Domain.Interface
{
    public interface IDevicePortDefService
    {
        Task<List<DevicePortDefDto>> Get();
        Task<DevicePortDefDto> Get(long Id);
        Task Update(DevicePortDefRequestDto entity);
        Task Delete(long Id);
        Task Create(DevicePortDefRequestDto entity);
    }
}
