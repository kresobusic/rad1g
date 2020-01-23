using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rad1G.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "OIB")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "OIB")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="Ime")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} mora biti {2} znakova dugačko.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdite lozinku")]
        [Compare("Password", ErrorMessage = "Lozinke ne odgovaraju.")]
        public string ConfirmPassword { get; set; }
    }
}
