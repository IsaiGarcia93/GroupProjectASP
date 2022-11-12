using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }
        
        public int ItemID { get; set; }
        public Item Item { get; set;  }
       
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
