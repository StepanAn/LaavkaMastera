using MyShop.Models;
using System;

namespace DataBase
{
    public class Data : IData
    {
        public IProductSearch Products { get; }

        public IRepozitory<Category> Categories { get; }

        public IRepozitory<Comment> Comments { get; }

        public IRepozitory<Customer> Customers { get; }
        public Data(IProductSearch pro, IRepozitory<Category> cat, IRepozitory<Comment> com, IRepozitory<Customer> cus)
        {
            Products = pro;
            Categories = cat;
            Comments = com;
            Customers = cus;
        }
    }
}
