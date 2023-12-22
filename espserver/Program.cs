using Business;
using Domain.Interface;
using Infrastructer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => { opt.SetSqlServerOptions(builder.Configuration); });
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddInfrastructures(builder.Configuration);

builder.Services.AddScoped<IEsp8266Service, Esp8266Service>();
builder.Services.AddScoped<IEspPortDefService, EspPortDefService>();
builder.Services.AddScoped<IReleChannelDefService, ReleChannelDefService>();


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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 
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
