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

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepository.GetAllComments();
        }

        public void Delete(int commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            if (comment != null)
            {
                _commentRepository.Delete(comment);
            }
        }
        // Add additional methods as needed...
    }
}
