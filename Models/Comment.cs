namespace TwitterCloneAPIUserAuth.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }
    }
}
