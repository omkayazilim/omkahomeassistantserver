
using Domain.Dto;

namespace Domain.Interface
{
    public interface IChannelOperationService
    {
        Task<List<PingResponseDto>> GetDeviceStatus();
        Task<ChannelStatResponseDto> GetChannelStat(long ChannelId);
        Task ChangeStatusChannel(long channelId, bool stat);
    }
}
