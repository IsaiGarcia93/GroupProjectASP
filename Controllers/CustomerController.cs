using GroupProjectASP.Data;
using GroupProjectASP.Models;
using GroupProjectASP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext _context;
        List<Item> itemList = new List<Item>();
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
        public async Task<IActionResult> AddtoCart(int id)
        {//need saving of cart
            Item cartItem = new Item();
            cartItem = await _context.Items.FindAsync(id);
            itemList.Add(cartItem);
            IEnumerable<Item> cart = itemList;

            return View(cart);
        }
    }
}
