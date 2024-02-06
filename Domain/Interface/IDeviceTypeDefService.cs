using Domain.Dto;

namespace Domain.Interface
{
    public interface IDeviceTypeDefService
    {
        Task<List<DeviceTypeDefDto>> Get();
        Task<DeviceTypeDefDto> Get(long Id);
        Task Update(DeviceTypeDefRequestDto entity);
        Task Delete(long Id);
        Task Create(DeviceTypeDefRequestDto entity);
    }
}
