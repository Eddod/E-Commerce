using Microsoft.AspNetCore.SignalR;

namespace Web_API.Hubs;

public class NotificationsHub : Hub<INotificationClient>
{

    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId).ReceiveNotification(
            $"Thank you for connecting {Context.User?.Identity?.Name}");
        await base.OnConnectedAsync();
    }
}

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}
