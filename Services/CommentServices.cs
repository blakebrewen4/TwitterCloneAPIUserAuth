using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Repositories;

namespace TwitterCloneAPIUserAuth.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Comment GetById(int commentId)
        {
            return _commentRepository.GetById(commentId);
        }

        public Comment Create(Comment comment)
        {
            return _commentRepository.Create(comment);
        }

        // Add additional methods as needed...
    }
}
