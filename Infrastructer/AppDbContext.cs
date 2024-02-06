using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Entities;

namespace Infrastructer
{
    public class AppDbContext : DbContext, IAppDbContext
    {

        public DbSet<DeviceDef> DeviceDef { get; set; }
        public DbSet<DevicePortDef> DevicePortDef { get; set; }
        public DbSet<DeviceTypeDef> DeviceTypeDef { get; set; }
        public DbSet<DeviceChannelDef> DeviceChannelDef { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceDef>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DevicePortDef>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DeviceTypeDef>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<DeviceChannelDef>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }



    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var path = Path.Combine(Directory.GetCurrentDirectory().Replace("Infrastructer", "espserver"), "appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory().Replace("Infrastructer", "espserver"), "appsettings.json"))
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            string connectionString = config[$"ConnectionStrings:Default"];
            builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("espserver"));
            return new AppDbContext(builder.Options);
        }
    }
}
