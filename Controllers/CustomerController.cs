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
        List<Item> itemList = new List<Item>();
        //List<Item> cart = new List<Item>();

        public CustomerController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddtoCart(int? id)
        {//need saving of cart

            List<Item> cart = new List<Item>();

            if (id == null)
            {
                cart = GetCart();
                return View("AddToCart", cart);
            }
            else
            {
                cart = GetCart();
                Item cartItem = new Item();
                cartItem = await _context.Items.FindAsync(id);

                cart.Add(cartItem);

                SaveCart(cart);


                return View(cart = GetCart());
            }

        }

        [HttpGet]
        public async Task<IActionResult> DeleteItem(int id)
        {
            List<Item> cart = GetCart();
            Item item = await _context.Items.FindAsync(id);

            cart.Remove(item);

            SaveCart(cart);

            return RedirectToAction("AddToCart", cart);
        }

        private List<Item> GetCart()
        {
            List<Item> cart = HttpContext.Session.GetJson<List<Item>>("Cart") ?? new List<Item>();
            return cart;
        }

        private void SaveCart(List<Item> cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

    }
}
