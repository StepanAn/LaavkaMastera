using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase
{
    class CommentRepozitory : IRepozitory<Comment>
    {
        private readonly ApplicationContext db;
        public CommentRepozitory(ApplicationContext _db)
        {
            db = _db;
        }
        public async Task AddAsync(Comment obj)
        {
            db.Comments.Add(obj);
            await db.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await db.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await db.Comments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Remove(Comment obj)
        {
            db.Comments.Remove(obj);
            await db.SaveChangesAsync();
        }

        public Task Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
