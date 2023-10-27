using System.ComponentModel.DataAnnotations;

namespace TwitterCloneAPIUserAuth.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int TweetId { get; set; }

        public Tweet Tweet { get; set; }
    }
}
