using System.Collections.Generic;

namespace MyShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Product> TovarsInCategory { get; set; }

    }
}
