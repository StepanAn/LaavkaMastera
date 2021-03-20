using DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System.Collections.Generic;
using System.Linq;
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
    }
}
