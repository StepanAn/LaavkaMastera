using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Customer
    {
        public DateTime TimeBuy { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public List<Product> Purchases { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
