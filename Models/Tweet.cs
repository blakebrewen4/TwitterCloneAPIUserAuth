﻿using System;
using System.Collections.Generic;

namespace TwitterCloneAPIUserAuth.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TweetLike> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public int RetweetCount { get; set; }
    }
}
