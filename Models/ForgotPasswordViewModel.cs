using System.ComponentModel.DataAnnotations;

namespace AGILEDataPortal.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
