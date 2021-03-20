using Microsoft.Extensions.DependencyInjection;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public static class ServiceProvider
    {
        public static void AddDataBase(this IServiceCollection services)
        {
            services.AddTransient<ApplicationContext>();
            services.AddTransient<IProductSearch, ProductRepozitory>();
            services.AddTransient<IRepozitory<Category>, CategoryRepozitory>();
            services.AddTransient<IRepozitory<Comment>, CommentRepozitory>();
            services.AddTransient<IRepozitory<Customer>, CustomerRepozitory>();
            services.AddTransient<IData, Data>();
        }
    }
}
