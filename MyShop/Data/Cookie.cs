using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyShop.Data
{
    public static class Cookie
    {
        public static T Get<T>(this HttpContext context, string key)
        {
            if (context.Request.Cookies.ContainsKey(key))
            {
                string content = context.Request.Cookies[key];
                T obj = JsonSerializer.Deserialize<T>(content);
                return obj;
            }
            else
            {
                return default(T);
            }
        }
    }
}
