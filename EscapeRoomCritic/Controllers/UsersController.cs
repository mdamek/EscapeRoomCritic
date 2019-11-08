using System.Collections.Generic;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoomCritic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;

        public UsersController(IIdentityService identityService, IUserService userService)
        {
            _identityService = identityService;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(Credentials credentials)
        {
            var user = _identityService.Authenticate(credentials.Username, credentials.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] User value)
        {
            _userService.Add(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User value)
        {
            _userService.Edit(id, value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
