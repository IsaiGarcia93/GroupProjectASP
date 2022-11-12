using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "A valid email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insert a valid password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match.")]
        public string ConfirmPassword { get; set; }
    }
}
