using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System.Collections.Generic;

namespace MyShop.Components
{
    public class TovarListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)
        {
            return View(products);
        }
    }
}
