using GroupProjectASP.Data;
using GroupProjectASP.Models;
using GroupProjectASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GroupProjectASP.Infrastructure;
using System.Threading.Tasks;

namespace GroupProjectASP.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ShoppingCart _shoppingCart;

        public CustomerController(AppDBContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        public ViewResult Cart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var cartViewModel = new CartViewModel
            {
                ShoppingCart = _shoppingCart,
                CartTotal = _shoppingCart.GetTotal()
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _context.Items.FirstOrDefault(c => c.ItemID == id);
            if(item != null)
            {
                _shoppingCart.AddToCart(item, 1);
            }
            return RedirectToAction("Cart");
        }

        public RedirectToActionResult DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(c => c.ItemID == id);
            if (item != null)
            {
                _shoppingCart.RemoveItem(item);
            }
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var titleList = "";
            foreach (var item in items)
            {
                titleList += item.Item.Title + ",";
            }
    
            var total = _shoppingCart.GetTotal();
            ViewBag.Name = titleList;
            ViewBag.Total = total;
     

            return View();


        }
    }
}
