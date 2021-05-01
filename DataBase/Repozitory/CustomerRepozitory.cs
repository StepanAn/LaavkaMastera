using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase
{
    class CustomerRepozitory : IRepozitory<Customer>
    {
        public Task AddAsync(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
