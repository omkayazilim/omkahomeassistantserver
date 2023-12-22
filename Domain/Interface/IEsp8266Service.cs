using Domain.Dto;

namespace Domain.Interface
{
    public interface IEsp8266Service
    {
        List<PortStatResponse> PostPinStat(PortStatDto std);
        Task<List<PortStatResponse>> GetPinStat();
        Task<List<PortPropsDto>> GetPortProps();
     
    }
}
