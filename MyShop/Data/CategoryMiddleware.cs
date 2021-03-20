using DataBase;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyShop.Data
{
    public class CategoryMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IData db;

        public CategoryMiddleware(RequestDelegate next, IData _db)
        {
            this._next = next;
            db = _db;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Static.Categories = await db.Categories.GetAllAsync();
            await _next.Invoke(context);
        }
        
    }
}
