using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IRepozitory<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task Update(T obj);
        Task Remove(T obj);
        Task AddAsync(T obj);
    }
}
