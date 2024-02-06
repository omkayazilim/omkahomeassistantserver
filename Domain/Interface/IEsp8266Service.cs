using Domain.Dto;

namespace Domain.Interface
{
    public interface IEsp8266Service
    {
        List<PortStatResponse> PostPinStat(PortStatDto std, string espUrl);
        Task<List<PortStatResponse>> GetPinStat(string espUrl);
        Task<List<PortPropsDto>> GetPortProps(string espUrl);
   


    }
}
