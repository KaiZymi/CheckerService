using BinanceClient;
using BybitClient;
using CheckerService.Core;
using CheckerService.Gateway.Configurations;
using Exchanges.Abstractions.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions(builder.Configuration);
builder.Services.AddControllers();
builder.Services.ConfigureSwaggerServices();
builder.Services.ConfigureMapper();

builder.Services.ConfigureCoreServices();
builder.Services.ConfigureBinanceServices(nameof(ExchangeTypeClientEnum.Binance));
builder.Services.ConfigureCoreBybitServices(nameof(ExchangeTypeClientEnum.ByBit));

var app = builder.Build();

app.ConfigureSwaggerPipeline();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();