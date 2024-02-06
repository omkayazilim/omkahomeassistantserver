using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Domain.Validations;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Business
{
    public class DevicePortDefService : ServiceBase, IDevicePortDefService
    {
        private readonly ILogger<DeviceDefService> _logger;
        private readonly IMapper _mapper;
        public DevicePortDefService(IAppDbContext dbContext, ILogger<DeviceDefService> logger,IMapper mapper) : base(dbContext)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Create(DevicePortDefRequestDto entity)
        {
            if (await _dbContext.DevicePortDef.AnyAsync(x => x.PortCode.Equals(entity.PortCode)))
                throw new Exception(message: "Port Zaten Tanımlı");

            var req = new DevicePortDef
            {
                PortDesc = entity.PortDesc,
                PortNumber = entity.PortNumber,
                PortCode = entity.PortCode,
                CreatedDate = DateTime.Now,
                CreatedUser = "Sys",
                DeviceId = entity.DeviceDefId,
                IOPortType = entity.IOPortType,
                IsActive = entity.IsActive,
            };
            _dbContext.DevicePortDef.Add(req);
           await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(long Id)
        {
         var entity=await   _dbContext.DevicePortDef.SingleAsync(x => x.Id ==Id);
            _dbContext.DevicePortDef.Remove(entity);
          await  _dbContext.SaveChangesAsync();
        }

        public async Task<List<DevicePortDefDto>> Get()
        {
            return _mapper.Map<List<DevicePortDefDto>>(await _dbContext.DevicePortDef.Include(i => i.DeviceDef).ToListAsync())??new List<DevicePortDefDto>();
        }

        public async Task<DevicePortDefDto> Get(long Id)
        {
            return _mapper.Map<DevicePortDefDto>(await _dbContext.DevicePortDef.Include(i => i.DeviceDef).SingleAsync(x=>x.Id==Id)) ?? new DevicePortDefDto();
        }

        public async Task Update(DevicePortDefRequestDto entity)
        {

            if (await _dbContext.DevicePortDef.AnyAsync(x => x.PortCode.Equals(entity.PortCode) && x.Id != entity.Id))
                throw new Exception(message: "Port Zaten Tanımlı");

            var req=  await _dbContext.DevicePortDef.SingleAsync(x => x.Id == entity.Id);
            req.PortDesc = entity.PortDesc;
            req.UpdatedDate = DateTime.Now;
            req.DeviceId = entity.DeviceDefId;
            req.IOPortType = entity.IOPortType;
            req.IsActive = entity.IsActive; 
            req.PortCode = entity.PortCode; 
            req.PortNumber = entity.PortNumber;
            req.UpdatedUser = "SYS";
            _dbContext.DevicePortDef.Update(req);
            await _dbContext.SaveChangesAsync();
                
        }
    }
}
