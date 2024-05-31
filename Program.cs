using dam_monitoring_signalr.Hubs;
using dam_monitoring_signalr.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    //.WithOrigins("https://localhost:44351"));
    .SetIsOriginAllowed(origin => true));

app.MapGet("/", () => $"Monitoring { AppState.Monitoring }%");

app.MapHub<MonitoringHub>("/monitoring");

app.Run();
