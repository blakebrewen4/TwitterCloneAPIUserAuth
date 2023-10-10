using Microsoft.AspNetCore.Identity;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Repositories;

namespace TwitterCloneAPIUserAuth.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(UserRepository userRepository, SignInManager<ApplicationUser> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        // Add additional methods for token generation, validation, etc...
    }
}
