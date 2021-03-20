using Microsoft.AspNetCore.Mvc;
using MyShop.ViewModel;
using System.Threading.Tasks;
using DataBase;
using MyShop.Data;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IData db;
        public HomeController(IData context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            Static.Categories = await db.Categories.GetAllAsync();
            IndexViewModel model = new()
            {
                Products = await db.Products.GetAllAsync(),
                Comments = await db.Comments.GetAllAsync()
            };

            return View(model);
        }

    }
}
