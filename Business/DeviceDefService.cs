
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Business
{
    public class DeviceDefService : ServiceBase, IDeviceDefService
    {
        private readonly ILogger<DeviceDefService> _logger;
        private readonly IMapper _mapper;
        public DeviceDefService(IAppDbContext dbContext, ILogger<DeviceDefService> logger, IMapper mapper) : base(dbContext)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Delete(long Id)
        {
            var entity = await this._dbContext.DeviceDef.SingleAsync(x => x.Id == Id);
            this._dbContext.DeviceDef.Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<List<DeviceDefDto>> Get()
        {
            return _mapper.Map<List<DeviceDefDto>>(await _dbContext.DeviceDef.Include(i => i.DeviceTypeDef).ToListAsync()) ?? new List<DeviceDefDto>();
        }

        public async Task<DeviceDefDto> Get(long Id)
        {
            var entity = await this._dbContext.DeviceDef.Include(i => i.DeviceTypeDef).SingleAsync(x => x.Id == Id);
            return _mapper.Map<DeviceDefDto>(entity) ?? new DeviceDefDto();
        }

        public async Task Update(DeviceDefRequestDto entity)
        {
            if (await _dbContext.DeviceDef.AnyAsync(x => (x.DeviceCode.Equals(entity.DeviceCode) || x.DeviceAdressUrl.Equals(entity.DeviceAdressUrl)) && x.Id != entity.Id))
                throw new Exception( message:"Cihaz Zaten Tanımlı");


           var req = await this._dbContext.DeviceDef.SingleAsync(x => x.Id == entity.Id);
           
            req.UpdatedDate = DateTime.Now;
            req.DeviceTypeId = entity.DeviceTypeDefId;
            req.DeviceName = entity.DeviceName;
            req.DeviceAdressUrl = entity.DeviceAdressUrl;
            req.DeviceCode = entity.DeviceCode;
            req.TotalIOPortCount = entity.TotalIOPortCount;
            _dbContext.DeviceDef.Update(req);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Create(DeviceDefRequestDto entity)
        {
            if (await _dbContext.DeviceDef.AnyAsync(x => x.DeviceCode.Equals(entity.DeviceCode) || x.DeviceAdressUrl.Equals(entity.DeviceAdressUrl)))
                throw new Exception(message: "Cihaz Zaten Tanımlı");

            var req = new DeviceDef
            {
                CreatedDate = DateTime.Now,
                CreatedUser = "SYS",
                DeviceAdressUrl = entity.DeviceAdressUrl,
                DeviceCode = entity.DeviceCode,
                DeviceName = entity.DeviceName,
                DeviceTypeId = entity.DeviceTypeDefId,
                IsActive = entity.IsActive,
                TotalIOPortCount = entity.TotalIOPortCount,
            };
            _dbContext.DeviceDef.Add(req);
            await _dbContext.SaveChangesAsync();


        }
    }
}
