
using Domain.Dto;

namespace Domain.Interface
{
    public interface IApiClientService
    {

        Task<T> GetAsync<T>(ApiClientRequestDto req);
        Task<T> PostAsync<T, T1>(ApiClientRequestDto<T1> req);
    }
}
