﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
           // Purchases = new List<string>();

        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

       // public string City { get; set; }

      //  public List<string> Purchases { get; set; }

    }
}
