namespace Petrolheads.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;
    using Petrolheads.Common;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Web.ViewModels.Chat;

    [Authorize]
    public class ChatHub : Hub
    {
        private static readonly ConnectionMappingHelper Connections =
            new ConnectionMappingHelper();

        private readonly IRepository<ApplicationUser> userRepository;

        public ChatHub(IRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message
                {
                    User = this.Context.User.Identity.Name,
                    Text = message,
                });
        }

        public override Task OnConnectedAsync()
        {
            string name = this.Context.User.Identity.Name;
            Connections.Add(name, this.Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = this.Context.User.Identity.Name;

            Connections.Remove(name, this.Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task GetAllActiveConnections()
        {
            var connectedUsers = new List<ConnectedUserInputModel>();
            var connectedUsersUsernames = Connections.GetConnections();

            foreach (var username in connectedUsersUsernames)
            {
                var user = this.userRepository
                    .All()
                    .Where(u => u.UserName == username)
                    .Select(u => new ConnectedUserInputModel()
                    {
                        ProfilePhotoUrl = u.ProfilePhotoUrl,
                        Username = u.UserName,
                        ProfileUrl = $"/Profiles/Cars?userId={u.Id}",
                    })
                    .FirstOrDefault();

                connectedUsers.Add(user);
            }

            await this.Clients.All.SendAsync("ConnectedUsers", connectedUsers);
        }
    }
}
