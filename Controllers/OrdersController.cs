using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupProjectASP.Data;
using GroupProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using GroupProjectASP.ViewModels;

namespace GroupProjectASP.Controllers
{
    
    
    public class OrdersController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(AppDBContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        // GET: Orders
       

        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CheckoutViewModel checkoutViewModel)
        {
            Order order = new Order();

            order.OrderID = checkoutViewModel.order.OrderID;
            order.FirstName = checkoutViewModel.order.FirstName;
            order.LastName = checkoutViewModel.order.LastName;
            order.Address = checkoutViewModel.order.Address;
            order.City = checkoutViewModel.order.City;
            order.State = checkoutViewModel.order.State;
            order.Zip = checkoutViewModel.order.Zip;
            order.OrderDate = checkoutViewModel.order.OrderDate;
            order.TotalPrice = checkoutViewModel.order.TotalPrice;
            order.CreditCardNumber = checkoutViewModel.order.CreditCardNumber;
            order.ExpirationDate = checkoutViewModel.order.ExpirationDate;

            order.CartString = checkoutViewModel.order.CartString;


            _shoppingCart.EmptyCart();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Complete");

        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,FirstName,LastName,Address,City,State,Zip,OrderDate,TotalPrice, CreditCardNumber, ExpirationDate, CartString")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }

        [HttpGet]
        public IActionResult Complete()
        {
            return View();
        }
    }
}
