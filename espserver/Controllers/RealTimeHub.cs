using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace espserver.Controllers
{
    public class RealTimeHub :Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
