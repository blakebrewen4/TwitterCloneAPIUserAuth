using Microsoft.AspNetCore.Identity;

namespace TwitterCloneAPIUserAuth.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional user properties, if needed
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        // DO NOT directly store passwords like this. This is just for the sake of illustration.
        // In a real-world scenario, use Identity's built-in password management and storage.
        // public string Password { get; set; }
    }
}
