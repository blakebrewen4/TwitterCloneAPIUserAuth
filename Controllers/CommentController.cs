using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Services;

namespace TwitterCloneAPIUserAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult<List<Comment>> GetAllComments()
        {
            return _commentService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            var comment = _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        [HttpPost]
        public ActionResult<Comment> CreateComment(Comment comment)
        {
            _commentService.Create(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var existingComment = _commentService.GetById(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            _commentService.Delete(id);
            return NoContent();
        }
    }
}
