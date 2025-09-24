using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using SfeirAPI.Domain.Posts;
using SfeirAPI.WebApi.Exceptions;

namespace SfeirAPI.WebApi.Controllers;

[ApiController]
[Route("posts")]
public class PostsController : ControllerBase
{
    private readonly IPostService _posts;
    private readonly ILogger<PostsController> _logger;

    public PostsController(IPostService posts, ILogger<PostsController>? logger = null)
    {
        _posts = posts;
        _logger = logger ?? new NullLogger<PostsController>();
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetPosts()
    {
        _logger.LogInformation("Trying to get posts from an external service");
        var allPosts = await _posts.GetPosts();
        return Ok(allPosts);
    }

    [HttpGet("log-exception")]
    public IActionResult ThrowException()
    {
        try
        {
            throw new SfeirException("This is an excepted exception thrown for demonstration purposes", "PostOperation");
        }
        catch (Exception ex)
        {
            var myId = Guid.NewGuid();
            _logger.LogError(ex, "Something went wrong with transaction id {MyI}", myId);
        }
        return Ok("A new exception should have been logged.");
    }
}