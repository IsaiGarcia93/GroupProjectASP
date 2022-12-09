using GroupProjectASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.ViewModels
{
    public class CheckoutViewModel
    {
        public Order order { get; set; }
        public DateTime PurchaseDate { get; set; }
        
        public List<ShoppingCartItem> cartItems { get; set; }
    }
}
