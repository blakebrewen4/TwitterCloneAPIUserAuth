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

        public IEnumerable<Tweet> GetAllTweets()
        {
            return _tweetRepository.GetAllTweets();
        }

        public Tweet CreateTweet(Tweet tweet)
        {
            return _tweetRepository.Create(tweet);
        }

        public void DeleteTweet(int tweetId)
        {
            var tweet = _tweetRepository.GetById(tweetId);
            if (tweet != null)
            {
                _tweetRepository.Delete(tweet);
            }
        }

        // Add additional methods as needed...
    }
}
