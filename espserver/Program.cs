using Business;
using Domain.Interface;
using Infrastructer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(opt => { opt.SetSqlServerOptions(builder.Configuration); });
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddInfrastructures(builder.Configuration);

builder.Services.AddScoped<IEsp8266Service, Esp8266Service>();
builder.Services.AddScoped<IDeviceDefService, DeviceDefService>();
builder.Services.AddScoped<IDeviceTypeDefService, DeviceTypeDefService>();
builder.Services.AddScoped<IDevicePortDefService, DevicePortDefService>();
builder.Services.AddScoped<IDeviceChannelDefService, DeviceChannelDefService>();
builder.Services.AddScoped<IApiClientService, ApiClientService>();
builder.Services.AddScoped<IChannelOperationService, ChannelOperationService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "crs",
                      builder =>
                      {
                          builder.WithOrigins("*")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.Enrich.FromLogContext()
.MinimumLevel.Information()
.WriteTo.Console()
.CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AppDbContext>();
    if (context != null)
    {
     //   await context.Database.MigrateAsync();
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder =>
        builder
        .WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
