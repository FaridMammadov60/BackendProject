using BackEndProject.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class Chat : Hub
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        public Chat(UserManager<AppUser> userManager, AppDbContext context)
        {            
            _userManager = userManager;
            _context = context;

        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            //await Clients.Others.SendAsync("ReceiveMessage", user, message);
           // await Clients.Caller.SendAsync("ReceiveMessage", user, message);

            //await Clients.Users.(user).SendAsync("ReceiveMessage", message);
            //await Clients.Group("p322").SendAsync("Group");
        }
        public override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser user = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                user.ConnectId = Context.ConnectionId;
                _userManager.UpdateAsync(user);
            }
            return base.OnConnectedAsync(); 
        }

        //public Task SendPrivateMessage(string groupName,string user, string message)
        //{
        //    return Clients.User(user).SendAsync("ReceiveMessage", message);
        //}
        public async Task SendMessageGroup(string groupName, string user, string message)
        {            
            await Clients.Group(groupName).SendAsync("GroupCreate", user, message);
        }
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
    }
}
