using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Repositories;

namespace TwitterCloneAPIUserAuth.Services
{
    public class AuthenticationService
    {
        private readonly UserRepository _userRepository;

        public AuthenticationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateCredentials(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user != null && user.Password == password) // This is a simple check, real-world apps should use hashed passwords!
            {
                return true;
            }
            return false;
        }

        // Add additional methods for token generation, validation, etc...
    }
}
