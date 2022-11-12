using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Please add a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must enter a description.")]
        public string Description { get; set; }

        [DisplayName("Date of Creation.")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DateOfCreation { get; set; }

        [Required(ErrorMessage = "Item requires a price.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Item requires an image.")]
        public string ImageUpload { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
