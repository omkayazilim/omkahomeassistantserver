using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructer
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<EspPort> EspPort { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EspPort>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
        public string getpath()
        {
            return Path.Combine(Directory.GetCurrentDirectory().Replace("Infrastructer", "espserver"), "appsettings.json");
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
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("espserver"));
            return new AppDbContext(builder.Options);
        }
    }
}
