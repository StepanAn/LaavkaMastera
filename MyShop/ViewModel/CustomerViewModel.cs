using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModel
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Не указан адрес")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Не указан телефон")]
        [Phone(ErrorMessage = "Некорректный телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage ="Некорректный email")]
        public string Email { get; set; }
    }
}
