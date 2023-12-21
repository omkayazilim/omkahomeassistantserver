using Domain.Dto;

namespace Domain.Interface
{
    public interface IEsp8266Service
    {
        List<PortStatResponse> PostPinStat(PortStatDto std);
        Task<List<PortStatResponse>> GetPinStat();
        string getpath();
        Task<List<PortPropsDto>> GetPortProps();
        Task NewPortProp(PortPropsSetRequestDto request);
        Task UpdatePortProp(PortPropsSetRequestDto request);
        Task DeletePortProp(long Id);
    }
}
