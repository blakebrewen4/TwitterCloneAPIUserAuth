using System.ComponentModel.DataAnnotations;

namespace TwitterCloneAPIUserAuth.Models
{


    public class Login
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,100}$", ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, and one number.")]
        public string Password { get; set; }
    }

}
