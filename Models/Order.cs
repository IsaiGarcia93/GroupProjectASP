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
        [DisplayName("First Name")]

        [Required(ErrorMessage = "First name is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]

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

        [DisplayName("Order Date: ")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]

        public DateTime OrderDate { get; set; }
        [DisplayName("Total Price: ")]

        public double TotalPrice { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

        [DisplayName("Credit Card Number")]
        //[RegularExpression(@"[0-9\s]{13,19}", ErrorMessage = "Please enter a valid credit card number.")]

        public int CreditCardNumber { get; set; }

        [DisplayName("Expiration Date")]
        public int ExpirationDate { get; set; }
        [DisplayName("Order List")]
        public string CartString { get; set; }
    }
}
