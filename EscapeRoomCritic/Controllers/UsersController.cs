using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(Credentials credentials)
        {
            var user = _identityService.Authenticate(credentials.Username, credentials.Password);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            return Ok(_userService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            return Ok(_userService.GetById(id));
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpPost]
        public ActionResult Post([FromBody] NewUserDto value)
        {
            _userService.Add(value);
            return Ok();
        }

        //[Authorize(Roles = Role.Visitor)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EditUserDto value)
        {
            _userService.Edit(id, value);
            return Ok();
        }

        //[Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
