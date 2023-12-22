
using Domain.Dto;
using Domain.Entities;
using Domain.Interface;
using Infrastructer;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class EspPortDefService : IEspPortDefService
    {
        private readonly IAppDbContext _context;
        public EspPortDefService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task Create(EspPortDefCreateRequestDto entity)
        {
            if (await _context.EspPortDef.AnyAsync(x => x.PortNumber == entity.PortNumber))
                throw new Exception("Port Zaten Tanımlı");

            _context.EspPortDef.Add(new EspPortDef
            {
                PortDesc = entity.PortDesc,
                PortKey = entity.PortKey,
                PortNumber = entity.PortNumber,
                //PortPropertyType = entity.PortPropertyType,
                //PortType = entity.PortType,
                IsActive = entity.IsActive, 
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(EspPortDefUpdateRequestDto entity)
        {
            _context.EspPortDef.Update(new EspPortDef
            {
                Id = entity.Id,
                PortDesc = entity.PortDesc,
                PortKey = entity.PortKey,
                PortNumber = entity.PortNumber,
                IsActive = entity.IsActive,
                UpdatedDate = DateTime.Now,
                UpdatedUser = "SYS"
            });
            await _context.SaveChangesAsync();
        }
        public async Task Delete(long id) 
        {
           var resp= await _context.EspPortDef.SingleAsync(x => x.Id == id);
            _context.EspPortDef.Remove(resp);   
            await _context.SaveChangesAsync();

        }
        public async Task<List<EspPortDefListItemDto>> Get()
        {
            return await _context.EspPortDef.Select(x => new EspPortDefListItemDto
            {
                Id = x.Id,
                IsActive = x.IsActive,
                PortDesc = x.PortDesc,
                PortKey = x.PortKey,
                PortNumber = x.PortNumber
           
            }).ToListAsync();



        }
        public async Task<EspPortDefListItemDto> Get(long Id)
        {
            var resp = await _context.EspPortDef.SingleAsync(x => x.Id == Id);
            return new EspPortDefListItemDto
            {
                Id = resp.Id,
                IsActive = resp.IsActive,
                PortDesc = resp.PortDesc,
                PortKey = resp.PortKey,
                PortNumber = resp.PortNumber
            };
        }
    }
}
