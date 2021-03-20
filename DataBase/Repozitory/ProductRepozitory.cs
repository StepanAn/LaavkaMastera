using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase
{
    public class ProductRepozitory : IProductSearch
    {
        private readonly ApplicationContext db;
        public ProductRepozitory(ApplicationContext _db)
        {
            db = _db;
        }
        public async Task AddAsync(Product obj)
        {
            db.Products.Add(obj);
            await db.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await db.Products.ToListAsync();
        }

        public Task<List<Product>> GetByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveAsync(Product obj)
        {
            db.Products.Remove(obj);
            await db.SaveChangesAsync();
        }

        public Task Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
