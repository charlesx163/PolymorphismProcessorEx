using PolymorphismProcessorEx.Core;
using PolymorphismProcessorEx.Core.PayloadProcessors;
using PolymorphismProcessorEx.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IJobExecutor, PolymorphismProcessorExecutor>();
builder.Services.AddSingleton<IPolymorphismProcessorWorker, PolymorphismProcessorWorker>();
builder.Services.AddSingleton<NormalPayloadProcessor>()
    .AddSingleton<ErrorPayloadProcessor>()
    .AddSingleton<PayloadProcessorFactory>(sp => messageType => messageType switch
    {
        MessageType.Info => sp.GetService<NormalPayloadProcessor>(),
        MessageType.Error => sp.GetService<ErrorPayloadProcessor>(),
        _ => null
    });
builder.Services.AddTransient<PayloadProcessorConfiguration>();
//register runner and config how many processors
builder.Services.AddSingleton(sp =>
{
    var payloadProcessorConfiguration = sp.GetService<PayloadProcessorConfiguration>()!;
    payloadProcessorConfiguration.AddProcessor(MessageType.Info)
    .AddProcessor(MessageType.Error);
    return payloadProcessorConfiguration.CreateRunner();


});
builder.Services.AddHostedService<PolymorphismProcessorBackgroundService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}