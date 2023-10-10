using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Repositories;

namespace TwitterCloneAPIUserAuth.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApplicationUser GetById(string userId)
        {
            return _userRepository.GetById(userId);
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            return _userRepository.Create(user);
        }

        // Add additional methods as needed...
    }
}
