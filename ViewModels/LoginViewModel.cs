using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please insert a valid email.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Add a valid password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
