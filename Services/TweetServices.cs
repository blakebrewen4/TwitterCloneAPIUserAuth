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

        public Tweet GetById(int tweetId)
        {
            return _tweetRepository.GetById(tweetId);
        }

        public Tweet Create(Tweet tweet)
        {
            return _tweetRepository.Create(tweet);
        }

        // Add additional methods as needed...
    }
}
