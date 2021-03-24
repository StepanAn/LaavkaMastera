using Microsoft.AspNetCore.Mvc;
using MyShop.ViewModel;
using System.Threading.Tasks;
using DataBase;
using MyShop.Data;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IData db;
        //private readonly ApplicationContext cont;
        public HomeController(IData context /*ApplicationContext _cont*/)
        {
            db = context;
            //cont = _cont;
            //Task<List<Category>> cats = db.Categories.GetAllAsync();
            //List<Category> categories = cats.Result;
            //for(int i=0; i<1000; i++)
            //{
            //    Random rd = new(i + 86);
            //    Category category = categories.FirstOrDefault(p => p.Id == rd.Next(1, 13));
            //    Category cat = new()
            //    {
            //        CategoryName = category.CategoryName,
            //        TovarsInCategory = category.TovarsInCategory,
            //    };
            //    Random rand = new(i);
            //    Random random = new(i + 27);
            //    Product prod = new()
            //    {
            //        Name = "Lorem Ipsum",
            //        LongDesc = @"Lorem ipsum dolor sit amet,
            //        consectetur adipiscing elit.Quisque feugiat est quis aliquam mollis.Vestibulum vel egestas ligula,
            //        vitae vulputate enim.Curabitur venenatis orci velit,
            //        mattis ullamcorper ante malesuada at.Duis tristique massa a dolor feugiat volutpat.Aliquam erat volutpat.Nunc fringilla,
            //        purus et sollicitudin volutpat,
            //        ipsum neque finibus neque,
            //        a suscipit urna nunc ac magna.Aliquam eu iaculis lectus.Nam hendrerit lectus eget fermentum mattis.Suspendisse luctus a risus eu molestie.Morbi convallis metus nec sapien aliquet rutrum.Aenean in diam mi.Duis semper vehicula leo,
            //        eu commodo dui hendrerit quis.",
            //        Category = cat,
            //        Img = "https://loremflickr.com/640/360",
            //        IsFavorite = rand.Next(10, 10000),
            //        Price = random.Next(100, 37000),
            //    };
            //    cont.Products.Add(prod);
            //    cont.SaveChanges();
            //}
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
