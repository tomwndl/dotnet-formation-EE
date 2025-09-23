using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace DependencyInjection;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserService _service;

  public UserController(IUserService service)
  {
    _service = service;
  }

  [HttpGet(template:"Get")]
  public ActionResult<User> GetUser(string login)
  {
    var user = _service.GetUser(login);
    if (user == null)
      return BadRequest();

    return Ok(user);
  }

  [HttpGet(template:"All")]
  public ActionResult<List<User>> AllUsers()
  {
    var users = _service.GetUsers();
    return Ok(users);
  }
}
