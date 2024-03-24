using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Business
{
    public class DeviceChannelDefService : ServiceBase, IDeviceChannelDefService
    {
        private readonly ILogger<DeviceDefService> _logger;
        private readonly IMapper _mapper;
        private readonly IApiClientService _apiClient;
        public DeviceChannelDefService(IAppDbContext dbContext, ILogger<DeviceDefService> logger, IMapper mapper, IApiClientService apiClient) : base(dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _apiClient = apiClient;
        }

        public async Task Create(DeviceChannelDefRequestDto entity)
        {
            if (await _dbContext.DeviceChannelDef.AnyAsync(x => x.DeviceChannelCode.Equals(entity.DeviceChannelCode) || x.DeviceChannelNo.Equals(entity.DeviceChannelNo)))
                throw new Exception(message: "Cihaz Zaten Tanımlı");

            var req = new DeviceChannelDef
            {
                DeviceChannelCode = entity.DeviceChannelCode,
                CreatedUser = "SYS",
                CreatedDate = DateTime.Now,
                DeviceChannelDesc = entity.DeviceChannelDesc,
                DeviceChannelNo = entity.DeviceChannelNo,
                DevicePortId = entity.DevicePortDefId,
                IsActive = entity.IsActive,
                DeviceChannelIcon = entity.DeviceChannelIcon,
            };
            if (req != null)
            {
                req.DevicePortId = entity.DevicePortDefId;
                _dbContext.DeviceChannelDef.Add(req);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long Id)
        {
            var entity = await _dbContext.DeviceChannelDef.SingleAsync(x => x.Id == Id);
            _dbContext.DeviceChannelDef.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DeviceChannelDefDto>> Get()
        {
            var result = _mapper.Map<List<DeviceChannelDefDto>>(await _dbContext.DeviceChannelDef.Include(i => i.DevicePortDef).ThenInclude(i => i.DeviceDef).ThenInclude(i => i.DeviceTypeDef).ToListAsync()) ?? new List<DeviceChannelDefDto>();

            var devices = await _dbContext.DeviceDef.Where(x => x.IsActive).ToListAsync();
            var portList = new List<DevicelistPortStatDto>();
            foreach (var entity in devices)
            {
                var stat = await _apiClient.GetAsync<List<PortStatResponse>>(new ApiClientRequestDto { RequestMetod = "getValues", RequestUrl = entity.DeviceAdressUrl });
                if (stat != null)
                    stat.ForEach(x => portList.Add(new DevicelistPortStatDto
                    {
                        PortNo = x.Pin,
                        DeviceId = entity.Id,
                        ChannelStatus = x.Value == 1 ? true : false
                    }));
            }

            result.ForEach(r => 
            {
               var val= portList.SingleOrDefault(x=>x.DeviceId==r.DevicePortDef.DeviceDef.Id && x.PortNo==r.DevicePortDef.PortNumber);
               r.ChannelStatus = val?.ChannelStatus??false;
            
            });
            return result;
        }

        public async Task<DeviceChannelDefDto> Get(long Id)
        {
            return _mapper.Map<DeviceChannelDefDto>(await _dbContext.DeviceChannelDef.Include(i => i.DevicePortDef).ThenInclude(i => i.DeviceDef).ThenInclude(i => i.DeviceTypeDef).SingleAsync(x => x.Id == Id)) ?? new DeviceChannelDefDto();
        }

        public async Task Update(DeviceChannelDefRequestDto entity)
        {
            if (await _dbContext.DeviceChannelDef.AnyAsync(x => (x.DeviceChannelCode.Equals(entity.DeviceChannelCode) || x.DeviceChannelNo.Equals(entity.DeviceChannelNo)) && x.Id != entity.Id))
                throw new Exception(message: "Cihaz Zaten Tanımlı");

            var req = await _dbContext.DeviceChannelDef.SingleAsync(x => x.Id == entity.Id);
            req.DeviceChannelDesc = entity.DeviceChannelDesc;
            req.DeviceChannelNo = entity.DeviceChannelNo;
            req.DeviceChannelCode = entity.DeviceChannelCode;
            req.UpdatedDate = DateTime.Now;
            req.DevicePortId = entity.DevicePortDefId;
            req.DeviceChannelIcon = entity.DeviceChannelIcon;
            _dbContext.DeviceChannelDef.Update(req);
            await _dbContext.SaveChangesAsync();

        }
    }
}
