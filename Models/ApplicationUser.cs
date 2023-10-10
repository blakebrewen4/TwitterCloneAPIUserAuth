using Microsoft.AspNetCore.Identity;
namespace TwitterCloneAPIUserAuth
{

    public class ApplicationUser : IdentityUser
    {
        // Additional user properties, if needed
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
