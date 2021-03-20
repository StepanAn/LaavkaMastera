using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase
{
    class CategoryRepozitory : IRepozitory<Category>
    {
        private readonly ApplicationContext db;
        public CategoryRepozitory(ApplicationContext _db)
        {
            db = _db;
        }
        public async Task AddAsync(Category obj)
        {
            db.Categories.Add(obj);
            await db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task RemoveAsync(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
