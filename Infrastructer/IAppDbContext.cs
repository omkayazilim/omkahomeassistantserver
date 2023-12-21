using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructer
{
    public interface IAppDbContext
    {
        public DbSet<EspPort> EspPort { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        string getpath();
    }
}
