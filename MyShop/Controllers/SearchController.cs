using DataBase;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class SearchController : Controller
    {
        private readonly IData db;
        public SearchController(IData context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> SearchByName(string name)
        {
            List<Product> products = await db.Products.GetByName(name);
            return View("Search", products);
        }
        [HttpGet]
        public async Task<IActionResult> Search(int? id)
        {
            if (id != null)
            {
                List<Product> products;
                products = await db.Products.GetByCategory((int)id);
                return View(products);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View("Search", await db.Products.GetAllAsync());
        }
    }
}
