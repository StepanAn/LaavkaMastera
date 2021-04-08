using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Product>> GetByCategory(int id)
        {
            return await db.Products.Where(p => p.CategoryId == id).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByName(string name)
        {
            return await db.Products.Where(p => p.Name == name).ToListAsync();
        }

        public async Task RemoveAsync(Product obj)
        {
            db.Products.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Product obj)
        {
            db.Products.Update(obj);
            await db.SaveChangesAsync();
        }
    }
}
