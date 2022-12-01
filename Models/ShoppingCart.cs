using GroupProjectASP.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class ShoppingCart
    {
        private readonly AppDBContext _context;

        public ShoppingCart(AppDBContext context)
        {
            _context = context;
        }

        public string ShoppingCartID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContext>();
            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();

            session.SetString("CartID", cartID);

            return new ShoppingCart(context) { ShoppingCartID = cartID };
        }

        public void AddToCart(Item item, int quantity)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(sh => sh.Item.ItemID == item.ItemID 
                                                                                && sh.ShoppingCartID == ShoppingCartID);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartID = ShoppingCartID,
                    Item = item,
                    Quantity = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveItem(Item item)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(sh => sh.Item.ItemID == item.ItemID 
                                                                                  && sh.ShoppingCartID == ShoppingCartID);

            var localQuantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
            return localQuantity;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(sh => sh.ShoppingCartID == ShoppingCartID)
                                                                                                .Include(sh => sh.Item).ToList());
        }

        public void EmptyCart()
        {
            var cartItems = _context.ShoppingCartItems.Where(sh => sh.ShoppingCartID == ShoppingCartID);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetTotal()
        {
            var total = _context.ShoppingCartItems.Where(sh => sh.ShoppingCartID == ShoppingCartID)
                                                            .Select(sh => sh.Item.Price * sh.Quantity).Sum();
            return (decimal)total;
        }
    }
}
