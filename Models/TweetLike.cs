using System.ComponentModel.DataAnnotations;

namespace TwitterCloneAPIUserAuth.Models
{
    public class TweetLike
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
    }
}
