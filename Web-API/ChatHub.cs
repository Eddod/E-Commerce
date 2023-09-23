using Microsoft.AspNetCore.SignalR;

namespace Web_API;

public class ChatHub : Hub<INotificationClient>
{
   
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId).ReceiveNotification(
            $"Thank you for connecting {Context.User?.Identity?.Name}");
        Console.WriteLine("Testarå");
        await base.OnConnectedAsync();
    }
}

public interface INotificationClient
{
    Task ReceiveNotification(string message);
}
