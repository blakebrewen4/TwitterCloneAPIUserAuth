using Microsoft.AspNetCore.Identity;

namespace TwitterCloneAPIUserAuth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        // You can further extend this with other fields like DateOfBirth, RegisteredDate, etc.
    }
}
