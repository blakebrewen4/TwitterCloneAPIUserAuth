using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TwitterCloneAPIUserAuth.Services;
using TwitterCloneAPIUserAuth.Models;

namespace TwitterCloneAPIUserAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.Name
            };

            var result = await _userService.RegisterUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Registration successful!" });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] LoginModel model)
        {
            var user = await _userService.AuthenticateAsync(model.Email, model.Password);
            if (user != null)
            {
                // Ideally, you should generate a token here for the authenticated user
                // Assuming you have a method _userService.GenerateToken(user)
                var token = _userService.GenerateToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class RegistrationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
