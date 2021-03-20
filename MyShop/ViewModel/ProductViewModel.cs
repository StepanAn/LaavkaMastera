using Microsoft.AspNetCore.Http;

namespace MyShop.ViewModel
{
    public class ProductViewModel
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public IFormFile Img { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public int CategoryId { get; set; }
    }
}
