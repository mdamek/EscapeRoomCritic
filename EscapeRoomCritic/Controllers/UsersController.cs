using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.Users;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoomCritic.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            return Ok(_userService.GetAll());
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Visitor + "," + Role.Admin)]
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            return Ok(_userService.GetById(id));
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post([FromBody] NewUserDto value)
        {
            _userService.Add(value);
            return Ok();
        }

        /// <summary>
        /// Edit user
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Visitor + "," + Role.Admin)]
        [HttpPut]
        public ActionResult Put(EditUserDto value)
        {
            _userService.Edit(value);
            return Ok();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
