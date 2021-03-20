using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IData db;
        private readonly string сartKey = "cart";
        public CartController(IData context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult AllCart()
        {
            var cart = GetCart();
            if (cart.Count != 0)
            {
                int totalPrice = 0;
                int amount = 0;
                foreach (var item in cart)
                {
                    totalPrice += item.TotalPrice;
                    amount += item.Amount;
                }
                ViewBag.TotalPrice = totalPrice;
                ViewBag.Amount = amount;
                return View(cart);
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> AddToCart(int? id)
        {

            if (id != null)
            {
                Product tovar = await db.Products.GetByIdAsync((int)id);
                if (tovar != null)
                {
                    bool finish = false;
                    CartItem item = new()
                    {
                        TovarInCart = tovar,
                        Amount = 1,
                        TotalPrice = tovar.Price,
                    };
                    var cart = GetCart();
                    foreach (var itemm in cart)
                    {
                        if (item.TovarInCart.Id == itemm.TovarInCart.Id)
                        {
                            itemm.Amount += 1;
                            itemm.TotalPrice = itemm.TovarInCart.Price * itemm.Amount;
                            finish = true;
                            SetCart(cart);
                            break;
                        }
                    }
                    if (!finish)
                    {
                        cart.Add(item);
                        SetCart(cart);
                    }
                    return RedirectToAction("AllCart");
                }
            }
            return NotFound();
        }

        public IActionResult Remove(int? tovarId)
        {
            if (tovarId != null)
            {
                var cart = GetCart();
                CartItem removeItem;
                removeItem = cart.FirstOrDefault(p => p.TovarInCart.Id == tovarId);
                if (removeItem != null)
                {
                    cart.Remove(removeItem);
                    SetCart(cart);
                    return RedirectToAction("AllCart");
                }
            }
            return NotFound();
        }
        public IActionResult Edit(int? tovarId, int? value)
        {
            if (tovarId != null && value != null)
            {
                var cart = GetCart();
                var editItem = cart.FirstOrDefault(p => p.TovarInCart.Id == tovarId);
                if (editItem != null)
                {
                    editItem.Amount += (int)value;
                    if (editItem.Amount == 0)
                        cart.Remove(editItem);
                    else
                        editItem.TotalPrice = editItem.Amount * editItem.TovarInCart.Price;
                    SetCart(cart);
                    return RedirectToAction("AllCart");
                }
            }
            return NotFound();
        }
        [NonAction]
        public List<CartItem> GetCart()
        {
            if (HttpContext.Request.Cookies.ContainsKey(сartKey))
            {
                string cart = HttpContext.Request.Cookies[сartKey];
                List<CartItem> items = JsonSerializer.Deserialize<List<CartItem>>(cart);
                return items;
            }
            else
            {
                List<CartItem> cart = new();
                return cart;
            }
        }
        [NonAction]
        public void SetCart(List<CartItem> items)
        {
            CookieOptions option = new();
            option.Expires = DateTime.Now.AddHours(10000);
            string cart = JsonSerializer.Serialize<List<CartItem>>(items);
            Response.Cookies.Append(сartKey, cart, option);
        }
    }
}