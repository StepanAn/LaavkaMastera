using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyShop.Data;
using System;
using System.Threading.Tasks;

namespace MyShop.Filters
{
    public class AdminFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (Static.IAdmin)
            {
                await next();
            }
            else
            {
                context.Result = new ContentResult { Content = "Вы не админ" };
            }
        }
    }
}