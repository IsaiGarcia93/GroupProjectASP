using GroupProjectASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.ViewModels
{
    public class CartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal CartTotal { get; set; }
    }
}
