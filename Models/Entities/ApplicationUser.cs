using Microsoft.AspNetCore.Identity;

namespace OkeMotor.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        public ICollection<Motor> Motors { get; set; }
    }
}
