using Microsoft.AspNetCore.Mvc;

namespace MyShop.Components
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
