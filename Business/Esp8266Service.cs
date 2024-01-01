using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace Business
{
    public class Esp8266Service : IEsp8266Service
    {
        private readonly IAppDbContext _dbContext;
        public Esp8266Service(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<PortStatResponse> PostPinStat(PortStatDto std)
        {
            string espurl = Environment.GetEnvironmentVariable("ESPURL") ?? "";
            string espset = Environment.GetEnvironmentVariable("ESPSET") ?? "";
            var client = new RestClient(espurl);

            var request = new RestRequest(espset);
            request.AddBody(std);
            var response = client.ExecutePost(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PortStatResponse>>(response.Content);//response.Content.ser;

            else throw response.ErrorException ?? new Exception();
        }

        public async Task<List<PortStatResponse>> GetPinStat()
        {
            string espurl = Environment.GetEnvironmentVariable("ESPURL") ?? "";
            var client = new RestClient(espurl);
            var request = new RestRequest("getValues");
            var response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<List<PortStatResponse>>(response.Content);//response.Content.ser;
            else throw response.ErrorException ?? new Exception();
        }
        public async Task<List<PortPropsDto>> GetPortProps()
        {
            var props = await _dbContext.EspPortDef.Select(x =>
            new PortPropsDto
            {
                Id = x.Id,
                PortDesc = x.PortDesc,
                PortKey = x.PortKey,
                PortNumber = x.PortNumber
              
            }
            ).ToListAsync();
            var statlist = await GetPinStat();

            var resp = (from dp in props
                        join pp in statlist on dp.PortNumber equals pp.Pin
                        select new PortPropsDto {
                            Id = dp.Id,
                            PortDesc = dp.PortDesc,
                            PortKey = dp.PortKey,
                            PortNumber = dp.PortNumber,
                            PortPropertyType = dp.PortPropertyType,
                            PortType = dp.PortType,
                            PinStat = pp?.Value >0? true:false,
                        }).ToList();

            return resp; 
        }

        public async Task<PingResponseDto> GetEspPing() {

            try
            { 
                var resp=await GetPinStat();
                return new PingResponseDto { Status = true, Desc = "Success"};
            }
            catch (Exception ex)
            {
                return new PingResponseDto { Status=false, Desc=ex.Message };
            }
         

        } 
    }
}
