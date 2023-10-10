using TwitterCloneAPIUserAuth.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TwitterCloneAPIUserAuth.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Comment GetById(int commentId)
        {
            return _context.Comments.AsNoTracking().FirstOrDefault(c => c.Id == commentId);
        }

        public Comment Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        // Add additional methods as needed...
    }
}
