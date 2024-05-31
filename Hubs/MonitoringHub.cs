using Microsoft.AspNetCore.SignalR;
using dam_monitoring_signalr.Shared;

namespace dam_monitoring_signalr.Hubs;

public class MonitoringHub : Hub
{
    public async Task SendMonitoring(int monitoring)
    {
        AppState.Monitoring = monitoring;

        await Clients.All.SendAsync(AppState.RECEIVE_MONITORING, monitoring);
    }
}
