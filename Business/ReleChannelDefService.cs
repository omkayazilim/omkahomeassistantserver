using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class ReleChannelDefService : IReleChannelDefService
    {
        private readonly IAppDbContext _context;
        private readonly IEsp8266Service _esp8266Service;
        public ReleChannelDefService(IAppDbContext context, IEsp8266Service esp8266Service)
        {
            _context = context;
            _esp8266Service = esp8266Service;
        }

        public async Task Create(ReleChannelCreateRequestDto entity)
        {
            _context.ReleChannelDef.Add(new ReleChannelDef
            {
                EspPortDefId = entity.EspPortDefId,
                IsActive = entity.IsActive,
                ReleChannelDesc = entity.ReleChannelDesc,
                ReleChannelName = entity.ReleChannelName,

            });

            await _context.SaveChangesAsync();
        }
        public async Task Update(ReleChannelCreateRequestDto entity)
        {
            _context.ReleChannelDef.Update(new ReleChannelDef
            {
                Id = entity.Id,
                EspPortDefId = entity.EspPortDefId,
                IsActive = entity.IsActive,
                ReleChannelDesc = entity.ReleChannelDesc,
                ReleChannelName = entity.ReleChannelName,
                UpdatedDate = DateTime.Now,
                CreatedUser = "SYS"

            });

            await _context.SaveChangesAsync();

        }
        public async Task Delete(long id)
        {
            var resp = await _context.ReleChannelDef.SingleAsync(x => x.Id == id);
            _context.ReleChannelDef.Remove(resp);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ReleChannelListItemDto>> Get()
        {
            var  resp= await _context.ReleChannelDef.Include(x => x.EspPortDef).Select(x => new ReleChannelListItemDto
            {
                Id = x.Id,
                EspPortDefId = x.EspPortDefId,
                IsActive = x.IsActive,
                ReleChannelDesc = x.ReleChannelDesc,
                ReleChannelName = x.ReleChannelName,
                PortDef = new EspPortDefListItemDto
                {
                    PortDesc = x.EspPortDef.PortDesc ,
                    Id = x.EspPortDef.Id,
                    PortKey = x.EspPortDef.PortKey,
                    PortNumber = x.EspPortDef.PortNumber
                }

            }).ToListAsync();

          var stats= await  _esp8266Service.GetPinStat();
            resp.ForEach(x => {
                x.ReleStat = stats.Single(c=> c.Pin==x.PortDef.PortNumber).Value >0?true:false;
            });
           return resp;
           
        }
        public async Task<ReleChannelListItemDto> Get(long Id)
        {
            var resp = await _context.ReleChannelDef.Include(x => x.EspPortDef).SingleAsync(x => x.Id == Id);
            return new ReleChannelListItemDto
            {
                Id = resp.Id,
                EspPortDefId = resp.EspPortDefId,
                IsActive = resp.IsActive,
                ReleChannelDesc = resp.ReleChannelDesc,
                ReleChannelName = resp.ReleChannelName,
                PortDef = new EspPortDefListItemDto
                {
                    PortDesc = resp.EspPortDef.PortDesc,
                    Id = resp.EspPortDef.Id,
                    PortKey = resp.EspPortDef.PortKey,
                    PortNumber = resp.EspPortDef.PortNumber
                }
            };
        }
    }
}
