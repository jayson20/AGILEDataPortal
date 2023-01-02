using System.ComponentModel.DataAnnotations;

namespace AGILEDataPortal.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
