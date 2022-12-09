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
using Microsoft.AspNetCore.Identity;

namespace GroupProjectASP.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CustomerController(AppDBContext context, ShoppingCart shoppingCart, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        public IActionResult Cart()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login", "Account");
            }
            else
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

        }
        
        public RedirectToActionResult AddToCart(int id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var item = _context.Items.FirstOrDefault(c => c.ItemID == id);
                if (item != null)
                {
                    _shoppingCart.AddToCart(item, 1);
                }
                return RedirectToAction("Cart");
            }
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
        public IActionResult Checkout()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var checkoutViewModel = new CheckoutViewModel 
            {
                cartItems = _shoppingCart.ShoppingCartItems,

                PurchaseDate = DateTime.Now 
            };

            var list = new List<ShoppingCartItem>();
            foreach (var item in _shoppingCart.ShoppingCartItems)
            {
                list.Add(item);
            }

            var cartString = "";
            foreach (var item in checkoutViewModel.cartItems)
            {
                cartString += ("("+ item.Quantity + ")" + item.Item.Title );

            }

            var total = _shoppingCart.GetTotal();
            ViewBag.Date = DateTime.Now.ToShortDateString();
            ViewBag.PDate = checkoutViewModel.PurchaseDate;
            ViewBag.Total = total;
            ViewBag.Cart = cartString;
            ViewBag.List = list;
            return View(checkoutViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel checkout)
        {
            Order order = new Order();

            order.OrderID = checkout.order.OrderID;
            order.FirstName = checkout.order.FirstName;
            order.LastName = checkout.order.LastName;
            order.Address = checkout.order.Address;
            order.City = checkout.order.City;
            order.State = checkout.order.State;
            order.Zip = checkout.order.Zip;
            order.OrderDate = checkout.order.OrderDate;
            order.TotalPrice = checkout.order.TotalPrice;
            order.CreditCardNumber = checkout.order.CreditCardNumber;


            //order.CartString =checkout.order.CartString;

            _context.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index", "Order");
        }
    }
}
