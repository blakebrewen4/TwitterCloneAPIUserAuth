using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterCloneAPIUserAuth.Models;
using TwitterCloneAPIUserAuth.Services;

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
        public async Task<ActionResult<List<Tweet>>> GetAllTweets()
        {
            return Ok(await _tweetService.GetAllTweetsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Tweet>> CreateTweet([FromBody] Tweet tweet)
        {
            try
            {
                return await _tweetService.CreateTweetAsync(tweet);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // You might want to provide a user-friendly message here
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTweet(int id)
        {
            await _tweetService.DeleteTweetAsync(id);
            return Ok();
        }

        // Endpoints for like, comment, and retweet functionalities can be added here
    }
}

