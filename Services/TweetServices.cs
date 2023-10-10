using System.Collections.Generic;
using System.Linq;
using TwitterCloneAPIUserAuth.Models;
using Microsoft.EntityFrameworkCore;
using TwitterCloneAPIUserAuth.Data;

namespace TwitterCloneAPIUserAuth.Services
{
    public class TweetService
    {
        private readonly ApplicationDbContext _context;

        public TweetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Tweet> GetAllTweets()
        {
            return _context.Tweets.Include(t => t.User).ToList();
        }

        public Tweet CreateTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            _context.SaveChanges();
            return tweet;
        }

        public void DeleteTweet(int id)
        {
            var tweet = _context.Tweets.FirstOrDefault(t => t.Id == id);
            if (tweet != null)
            {
                _context.Tweets.Remove(tweet);
                _context.SaveChanges();
            }
        }

        // Additional methods for like, comment, and retweet can be added
    }
}
