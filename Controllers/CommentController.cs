using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Services;
using System.Linq;

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
            return Ok(_commentService.GetAll().ToList());
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
