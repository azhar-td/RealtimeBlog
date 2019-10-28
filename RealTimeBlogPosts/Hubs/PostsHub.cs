using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using RealTimeBlogPosts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeBlogPosts.Hubs
{
    public class PostsHub:Microsoft.AspNetCore.SignalR.Hub 
    {
        public async Task SendCreatedPost(Post post)
        {
            //var context = GlobalHost.ConnectionManager.GetHubContext("PostsHub");

            await Clients.All.SendAsync("NewPostCreated",post);
        }
        public async Task Send(Post post)
        {
            //var context = GlobalHost.ConnectionManager.GetHubContext("PostsHub");

            await Clients.All.SendAsync("NewPost", "Message");
        }
    }
}
