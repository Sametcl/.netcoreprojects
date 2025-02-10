using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class AppUser:IdentityUser
    {
        public string? Fullname { get; set; }

    }
}
