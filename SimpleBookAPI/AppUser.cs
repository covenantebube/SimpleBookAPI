using Microsoft.AspNetCore.Identity;

namespace SimpleBookAPI
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } 
    }
}
