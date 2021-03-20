using Microsoft.AspNetCore.Mvc;
using MyShop.Filters;
using MyShop.Models;
using System.Threading.Tasks;
using DataBase;
using MyShop.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MyShop.Data;

namespace MyShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IData db;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ApplicationContext context2;
        public ProductController(IData context, IWebHostEnvironment appEnvironment, ApplicationContext context1)
        {
            db = context;
            _appEnvironment = appEnvironment;
            context2 = context1;
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Product product;
                product = await db.Products.GetByIdAsync((int)id);
                return View(product);
            }
            return NotFound();
        }
        [HttpGet]
        [AdminFilter]
        public async Task<IActionResult> Create()
        {
            var categories = await db.Categories.GetAllAsync();
            return View(categories);
        }
        [HttpPost]
        [AdminFilter]
        public async Task<IActionResult> Create(Product product)
        {
            //if(product != null)
            //{
            //    if(product.Img != null)
            //    {
            //        string path = "/img/" + product.Img.FileName;
            //        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //        {
            //            await product.Img.CopyToAsync(fileStream);
            //        }
            //        Category category = await db.Categories.GetByIdAsync(product.CategoryId);
            //        Product newProduct = new()
            //        {
            //            Img = path,
            //            ShortDesc = product.ShortDesc,
            //            LongDesc = product.LongDesc,
            //            Name = product.Name,
            //            Price = product.Price,
            //            Category = category
            //        };
            //        context2.Products.Add(newProduct);
            //        context2.SaveChanges();
            //    }
            //}
            //context2.Products.Add(product);
            //await context2.SaveChangesAsync();
            await db.Products.AddAsync(product);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Loginn(int password)
        {
            if(password == Static.Password)
            {
                Static.IAdmin = true;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}