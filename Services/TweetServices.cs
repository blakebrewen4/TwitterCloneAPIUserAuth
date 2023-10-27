using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Repositories;

namespace TwitterCloneAPIUserAuth.Services
{
    public class TweetService
    {
        private readonly TweetRepository _tweetRepository;

        public TweetService(TweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public async Task<Tweet> GetByIdAsync(int tweetId)
        {
            return await _tweetRepository.GetByIdAsync(tweetId);
        }

        public async Task<IEnumerable<Tweet>> GetAllTweetsAsync()
        {
            return await _tweetRepository.GetAllTweetsAsync();
        }

        public async Task<bool> HasUserTweetedSameContentBeforeAsync(string userId, string content)
        {
            return await _tweetRepository.HasUserTweetedSameContentBeforeAsync(userId, content);
        }

        public async Task<Tweet> CreateTweetAsync(Tweet tweet)
        {
            if (await _tweetRepository.HasUserTweetedSameContentBeforeAsync(tweet.UserId, tweet.Content))
            {
                throw new InvalidOperationException("You have already tweeted this content.");
            }
            return await _tweetRepository.CreateAsync(tweet);
        }

        public async Task DeleteTweetAsync(int tweetId)
        {
            var tweet = await _tweetRepository.GetByIdAsync(tweetId);
            if (tweet != null)
            {
                await _tweetRepository.DeleteAsync(tweet);
            }
        }
    }
}


