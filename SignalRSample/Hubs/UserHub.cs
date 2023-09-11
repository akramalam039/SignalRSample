using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;
        public static int TotallUsers { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotallUsers++;
            Clients.All.SendAsync("updateTotalUser", TotallUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            TotallUsers--;
            Clients.All.SendAsync("updateTotalUser", TotallUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            ///send update to all Clients that total view have been updated
            await Clients.All.SendAsync("updateTotalViews", TotalViews);// 'updateTotalViews' is the js method located in userCount.js file to call the client side 

        }
    }
}
