using Microsoft.AspNetCore.Identity;
using TwitterCloneShared.SharedModels;
using TwitterCloneAPIUserAuth.Repositories;
using System.Threading.Tasks;

namespace TwitterCloneAPIUserAuth.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(UserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public User GetById(string userId)
        {
            return _userRepository.GetById(userId);
        }

        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public async Task<IdentityResult> RegisterUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }

    }
}

