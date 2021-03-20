using DataBase;
using Microsoft.AspNetCore.SignalR;
using MyShop.Models;
using MyShop.ViewModel;
using System.Threading.Tasks;

namespace MyShop
{
    public class CommentHub : Hub
    {
        private readonly IData db;
        public CommentHub(IData context)
        {
            db = context;
        }
        public async Task Send(Comment comment)
        {
            db.Comments.AddAsync(comment);
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
