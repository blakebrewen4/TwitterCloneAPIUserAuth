using Microsoft.AspNetCore.Identity;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Repositories;
using System.Threading.Tasks;

namespace TwitterCloneAPIUserAuth.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public ApplicationUser GetById(string userId)
        {
            return _userRepository.GetById(userId);
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            return _userRepository.Create(user);
        }

        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> AuthenticateAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }

        // Dummy method for generating a token
        public string GenerateToken(ApplicationUser user)
        {
            // For now, just returning a string as a placeholder token
            return "dummy_token_for_" + user.Email;
        }
    }
}

