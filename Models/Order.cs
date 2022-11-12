using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [DisplayName("Date of Order")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
