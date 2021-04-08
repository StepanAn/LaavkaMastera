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
        public ProductController(IData context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            if (product != null)
            {
                if (product.Img != null)
                {
                    string path = "/img/" + product.Img.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await product.Img.CopyToAsync(fileStream);
                    }
                    Category category = await db.Categories.GetByIdAsync(product.CategoryId);
                    Product newProduct = new()
                    {
                        Img = path,
                        LongDesc = product.LongDesc,
                        Name = product.Name,
                        Price = product.Price,
                        CategoryId = category.Id
                    };
                    await db.Products.AddAsync(newProduct);
                }
            }
            
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
        [AdminFilter]
        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            Product product = await db.Products.GetByIdAsync(productId);
            EditViewModel viewModel = new()
            {
                Price = product.Price,
                Name = product.Name,
                LongDesc = product.LongDesc,
                Img = product.Img,
                IsFavorite = product.IsFavorite,
                Categories = await db.Categories.GetAllAsync(),
                Id = product.Id
            };
            return View(viewModel);
        }
        [AdminFilter]
        [HttpPost]
        public async Task<IActionResult> Editt(Product product)
        {
            await db.Products.Update(product);
            return RedirectToAction("Index", "Home");
        }
        [AdminFilter]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [AdminFilter]
        [HttpPost]
        public async Task<IActionResult> AddCategoryy(string categoryName)
        {
            await db.Categories.AddAsync(new Category()
            {
                CategoryName = categoryName,
            });
            return RedirectToAction("Index", "Home");
        }
        [AdminFilter]
        public async Task<IActionResult> Delete(int productId)
        {
            Product product = await db.Products.GetByIdAsync(productId);
            await db.Products.RemoveAsync(product);
            return RedirectToAction("Index", "Home");
        }
    }
}