using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterCloneAPIUserAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace TwitterCloneAPIUserAuth.Repositories
{
    public class TweetRepository
    {
        private readonly ApplicationDbContext _context;

        public TweetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tweet> GetByIdAsync(int tweetId)
        {
            return await _context.Tweets.FirstOrDefaultAsync(t => t.Id == tweetId);
        }

        public async Task<Tweet> CreateAsync(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();
            return tweet;
        }

        public async Task<IEnumerable<Tweet>> GetAllTweetsAsync()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task DeleteAsync(Tweet tweet)
        {
            _context.Tweets.Remove(tweet);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasUserTweetedSameContentBeforeAsync(string userId, string content)
        {
            return await _context.Tweets.AnyAsync(t => t.UserId == userId && t.Content == content);
        }
    }
}
