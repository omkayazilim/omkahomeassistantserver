
using AutoMapper;
using Domain.Dto;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Business
{
    public class ChannelOperationService:ServiceBase, IChannelOperationService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IApiClientService _apiClient;  
        public ChannelOperationService(
            IAppDbContext dbContext, 
            IMapper mapper,                  
            IApiClientService apiClient
            ) : base(dbContext)
        {
            _logger =Log.ForContext<ChannelOperationService>();    
            _mapper = mapper;
            _apiClient = apiClient;
        }

        public async Task<ChannelStatResponseDto> GetChannelStat(long ChannelId)
        {
            var channel= await _dbContext.DeviceChannelDef.Include(i=>i.DevicePortDef).ThenInclude(i=>i.DeviceDef).SingleAsync(x=>x.Id == ChannelId);
            var stat = await _apiClient.GetAsync<List<PortStatResponse>>(new ApiClientRequestDto { RequestMetod = "getValues", RequestUrl = channel.DevicePortDef.DeviceDef.DeviceAdressUrl });
            var port=stat.SingleOrDefault(x => x.Pin == channel.DevicePortDef.PortNumber);
            return new ChannelStatResponseDto {
                ChannelId = channel.Id,
                ChannelName = channel.DeviceChannelDesc,
                ChannelStatus = port.Value == 1 ? true : false,
                ChannelNo=port.Pin
            };
        }

        public async Task<List<PingResponseDto>> GetDeviceStatus()
        {
           var resp= new List<PingResponseDto>();
          var devices = await _dbContext.DeviceDef.Include(i=>i.DeviceTypeDef).Where(x=>x.IsActive).ToListAsync();
            devices.ForEach( x => 
            {
                var stat = _apiClient.GetAsync<List<PortStatResponse>>(new ApiClientRequestDto { RequestMetod = "getValues", RequestUrl = x.DeviceAdressUrl }).GetAwaiter().GetResult();
                if (stat.Any()) 
                {
                    resp.Add(new PingResponseDto { DeviceName=x.DeviceName, Status=true});
                _logger.Information($"{x.DeviceName } Status On Awaible");
                }
                else 
                { resp.Add(new PingResponseDto { DeviceName = x.DeviceName, Status = false });
                    _logger.Error($"{x.DeviceName} Status Non Awaible");
                }
              
            });
            return  resp;
        }
    }
}
