using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterCloneAPIUserAuth.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        [Required, MaxLength(280)]
        public string Content { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TweetLike> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public int RetweetCount { get; set; }
    }
}
