using MyShop.Models;
using System.Collections.Generic;

namespace MyShop.ViewModel
{
    public class EditViewModel : Product
    {
        public List<Category> Categories { get; set; }
    }
}
