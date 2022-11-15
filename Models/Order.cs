using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [Column(TypeName = "nvarchar(2)")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip code is required.")]
        [Column(TypeName = "nvarchar(6)")]
        public string Zip { get; set; }

        [DisplayName("Date of Order")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
