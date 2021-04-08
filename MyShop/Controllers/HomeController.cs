using Microsoft.AspNetCore.Mvc;
using MyShop.ViewModel;
using System.Threading.Tasks;
using DataBase;
using MyShop.Data;
using System;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IData db;
        private readonly ApplicationContext cont;
        public HomeController(IData context, ApplicationContext context1)
        {
            db = context;
            cont = context1;
            //cont.Categories.AddRange(Static.Cats);
            //cont.Products.AddRange(Static.Products);
            //cont.SaveChanges();
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
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public void WriteUs(string name, string message)
        {
            string letter = String.Format(@"
            Имя:<br>
            {0}<br>
            Письмо:
            {1}<br>
            ", name, message);
            EmailService emailService = new();
            emailService.SendEmail(letter);

        }

    }
}
