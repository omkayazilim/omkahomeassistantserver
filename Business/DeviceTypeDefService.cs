
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class DeviceTypeDefService : ServiceBase, IDeviceTypeDefService
    {
        private readonly ILogger<DeviceDefService> _logger;
        private readonly IMapper _mapper;
        public DeviceTypeDefService(IAppDbContext dbContext, ILogger<DeviceDefService> logger, IMapper mapper) : base(dbContext)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Create(DeviceTypeDefRequestDto entity)
        {
            if (await _dbContext.DeviceTypeDef.AnyAsync(x => (x.DeviceType == entity.DeviceType)))
                throw new Exception(message: "Cihaz Tipi Zaten Tanımlı");

            var req = new DeviceTypeDef()
            {
                CreatedDate = DateTime.Now,
                DeviceType = entity.DeviceType,
                CreatedUser = "",
                DeviceTypeDesc = entity.DeviceTypeDesc,
                IsActive = entity.IsActive
            };
            if (req != null)
            {
                _dbContext.DeviceTypeDef.Add(req);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long Id)
        {
            var entity = await _dbContext.DeviceTypeDef.SingleAsync(x => x.Id == Id);
            _dbContext.DeviceTypeDef.Remove(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<DeviceTypeDefDto>> Get()
        {
            return _mapper.Map<List<DeviceTypeDefDto>>(await _dbContext.DeviceTypeDef.ToListAsync()) ?? new List<DeviceTypeDefDto>();
        }

        public async Task<DeviceTypeDefDto> Get(long Id)
        {
            var entity = await _dbContext.DeviceTypeDef.SingleAsync(x => x.Id == Id);
            return _mapper.Map<DeviceTypeDefDto>(entity) ?? new DeviceTypeDefDto();
        }

        public async Task Update(DeviceTypeDefRequestDto entity)
        {
            if (await _dbContext.DeviceTypeDef.AnyAsync(x => (x.DeviceType == entity.DeviceType) && x.Id != entity.Id))
                throw new Exception(message: "Cihaz Tipi Zaten Tanımlı");

            var req = await _dbContext.DeviceTypeDef.SingleAsync(x => x.Id == entity.Id);
            req.DeviceTypeDesc = entity.DeviceTypeDesc;
            req.IsActive = entity.IsActive;
            req.UpdatedDate = DateTime.Now;
            req.DeviceType = entity.DeviceType;
            req.DeviceTypeDesc = entity.DeviceTypeDesc;
            req.UpdatedUser = "SYS";
            _dbContext.DeviceTypeDef.Update(req);
            await _dbContext.SaveChangesAsync();
        }
    }
}
