using MyShop.Models;
using System.Collections.Generic;

namespace MyShop.ViewModel
{
    public class IndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
