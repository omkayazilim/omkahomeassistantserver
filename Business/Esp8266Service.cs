using Domain.Dto;
using Domain.Interface;
using Infrastructer;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
namespace Business
{
    public class Esp8266Service : IEsp8266Service
    {
        private readonly IAppDbContext _dbContext;
        private readonly ILogger<Esp8266Service> _logger;
        public Esp8266Service(IAppDbContext dbContext, ILogger<Esp8266Service> log)
        {
            _logger = log;
            _dbContext = dbContext;
        }
        public List<PortStatResponse> PostPinStat(PortStatDto std, string espUrl)
        {
            string espset = Environment.GetEnvironmentVariable("ESPSET") ?? "";
            var client = new RestClient(espUrl);
           
            var request = new RestRequest(espset);
            request.AddBody(std);
            var response = client.ExecutePost(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PortStatResponse>>(response.Content);//response.Content.ser;

          
            else throw response.ErrorException ?? new Exception();
        }

        public async Task<List<PortStatResponse>> GetPinStat(string espUrl)
        {
            var client = new RestClient(espUrl);
            var request = new RestRequest("getValues");
            var response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PortStatResponse>>(response.Content);//response.Content.ser;
            else throw response.ErrorException ?? new Exception();
        }
        public async Task<List<PortPropsDto>> GetPortProps(string espUrl)
        {
       

            return null; 
        }

    }
}
