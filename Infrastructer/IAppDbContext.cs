using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructer
{
    public interface IAppDbContext
    {
         DbSet<EspPortDef> EspPortDef { get; set; }
         DbSet<ReleChannelDef> ReleChannelDef { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
