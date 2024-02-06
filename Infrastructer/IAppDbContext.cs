using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructer
{
    public interface IAppDbContext
    {
         DbSet<DeviceDef> DeviceDef { get; set; }
         DbSet<DevicePortDef> DevicePortDef { get; set; }
         DbSet<DeviceTypeDef> DeviceTypeDef { get; set; }
         DbSet<DeviceChannelDef> DeviceChannelDef { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
