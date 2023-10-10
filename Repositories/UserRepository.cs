using Microsoft.EntityFrameworkCore;
using System.Linq;
using TwitterCloneAPIUserAuth;
using TwitterCloneAPIUserAuth.Models;

namespace TwitterCloneAPIUserAuth.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetById(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public ApplicationUser GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // Implement similar methods for TweetRepository and CommentRepository, adjusted for their respective entity types.
    }
}
