
using Domain.Dto;
using Domain.Interface;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;

namespace Business
{
    public class ApiClientService:IApiClientService
    {
        private readonly ILogger _logger; 
        public ApiClientService()
        {
            _logger=Log.ForContext<ApiClientService>();
        }
        public async Task<T> GetAsync<T>(ApiClientRequestDto req) 
        {
            try
            {

          
            var opt = new RestClientOptions(req.RequestUrl);
            opt.MaxTimeout = 10000;
            using var client = new RestClient(opt);
            var request = new RestRequest(req.RequestMetod);
         
            var response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(response.Content);//response.Content.ser;
            else throw response.ErrorException ?? new Exception();
            }
            catch (TimeoutException)
            {

                return default;
            }
            catch (Exception)
            {

                throw default;
            }
        }
        public async Task<T> PostAsync<T,T1>(ApiClientRequestDto<T1> req)
        {
            var opt = new RestClientOptions(req.RequestUrl);
            opt.MaxTimeout = 10000;
            using var client = new RestClient(opt);
            var request = new RestRequest(req.RequestMetod);
            request.AddBody(req.RequestData);
            var response = await client.ExecutePostAsync(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(response.Content);
            else throw response.ErrorException ?? new Exception();
        }
    }
}
