using MyShop.Models;

namespace DataBase
{
    public interface IData
    {
        public IProductSearch Products { get; }
        public IRepozitory<Category> Categories { get; }
        public IRepozitory<Comment> Comments { get; }
        public IRepozitory<Customer> Customers { get; }
    }
}
