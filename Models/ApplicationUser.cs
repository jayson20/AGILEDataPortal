using Microsoft.AspNetCore.Identity;

namespace AGILEDataPortal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPassWordChanged { get; set; } = false;

    }
}
