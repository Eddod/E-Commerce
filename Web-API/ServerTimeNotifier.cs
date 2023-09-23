using Microsoft.AspNetCore.SignalR;

namespace Web_API;

public class ServerTimeNotifier : BackgroundService
{
   private static readonly TimeSpan _interval = TimeSpan.FromSeconds(5);
    private readonly ILogger<ServerTimeNotifier> _logger;
    private readonly IHubContext<ChatHub, INotificationClient> _hubContext;

    public ServerTimeNotifier(IHubContext<ChatHub, INotificationClient> hubContext, ILogger<ServerTimeNotifier> logger)
    {
        _hubContext = hubContext;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(_interval);

        while (!stoppingToken.IsCancellationRequested
            && await timer.WaitForNextTickAsync(stoppingToken))
        {
            var dateTime = DateTime.Now;
            _logger.LogInformation("Executing {Service} {Time}", nameof(ServerTimeNotifier), dateTime);

            await _hubContext.Clients.All.ReceiveNotification($"Server time is {dateTime}");
        }
    }
}
