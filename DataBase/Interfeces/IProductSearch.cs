using MyShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IProductSearch : IRepozitory<Product>
    {
        Task<List<Product>> GetByCategory(int id);
    }
}
