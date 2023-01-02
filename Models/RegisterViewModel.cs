using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AGILEDataPortal.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Required*")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name ="Confim Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string LastName { get; set; }
    }
}
