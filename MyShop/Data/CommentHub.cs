using DataBase;
using Microsoft.AspNetCore.SignalR;
using MyShop.Models;
using MyShop.ViewModel;
using System.Threading.Tasks;

namespace MyShop
{
    public class CommentHub : Hub
    {
        private readonly ApplicationContext db;
        public CommentHub(ApplicationContext context)
        {
            db = context;
        }
        public async Task Send(Comment comment)
        {
            db.Comments.Add(comment);
            await db.SaveChangesAsync();
            CommentViewModel com = new()
            {
                NameUser = comment.NameUser,
                Letter = comment.Letter,
                CommentDate = comment.CommentDate.ToLocalTime().ToString()
            };
            await this.Clients.All.SendAsync("Send", com);
        }
    }
}
