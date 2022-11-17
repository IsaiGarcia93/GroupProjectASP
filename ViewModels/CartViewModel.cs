using GroupProjectASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
