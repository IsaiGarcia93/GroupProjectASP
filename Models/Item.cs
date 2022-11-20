using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Please add a title.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Must enter a description.")]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [DisplayName("Date of Creation")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DateOfCreation { get; set; }

        [Required(ErrorMessage = "Item requires a price.")]
        public double Price { get; set; }

        [DisplayName("Item Image")]
        public string ImageUpload { get; set; }

        [NotMapped]
        [DisplayName("Image")]
        public IFormFile Image { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
