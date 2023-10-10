using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Services;
using System.Linq;

namespace TwitterCloneAPIUserAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly TweetService _tweetService;

        public TweetController(TweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpGet]
        public ActionResult<List<Tweet>> GetAllTweets()
        {
            return Ok(_tweetService.GetAllTweets().ToList());
        }

        [HttpPost]
        public ActionResult<Tweet> CreateTweet([FromBody] Tweet tweet)
        {
            return _tweetService.CreateTweet(tweet);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTweet(int id)
        {
            _tweetService.DeleteTweet(id);
            return Ok();
        }

        // Endpoints for like, comment, and retweet functionalities can be added here
    }
}
