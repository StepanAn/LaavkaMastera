using MyShop.Models;
using System.Collections.Generic;

namespace MyShop.Data
{
    public class Static
    {
        public static List<CartItem> Cart = new();
        public static bool IAdmin = false;
        public const int Password = 1111;
        public static int ItemId = 1;
        public static List<Category> Categories;
    }

}
