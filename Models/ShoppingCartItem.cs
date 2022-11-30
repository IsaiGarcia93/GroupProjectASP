using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemID { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string ShoppingCartID { get; set; }
    }
}
