using System.Collections.Generic;
using EscapeRoomCritic.Core.DTOs.EscapeRooms;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoomCritic.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EscapeRoomsController : ControllerBase
    {
        private readonly IEscapeRoomService _escapeRoomService;

        public EscapeRoomsController(IEscapeRoomService escapeRoomService)
        {
            _escapeRoomService = escapeRoomService;
        }


        /// <summary>
        /// Get all escape rooms
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<EscapeRoomDto>> Get()
        {
            return Ok(_escapeRoomService.GetAll());
        }

        /// <summary>
        /// Get escape room by id
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<EscapeRoomDto> Get(int id)
        {
            return Ok(_escapeRoomService.GetById(id));
        }

        /// <summary>
        /// Add escape room
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Owner + ", " + Role.Admin)]
        [HttpPost]
        public ActionResult Post([FromBody] NewEscapeRoomDto value)
        {
            _escapeRoomService.Add(value);
            return Ok();
        }

        /// <summary>
        /// Edit escape room
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Owner + ", " + Role.Admin)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EditEscapeRoomDto value)
        {
            _escapeRoomService.Edit(id, value);
            return Ok();
        }

        /// <summary>
        /// Delete escape room
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Owner + ", " + Role.Admin)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _escapeRoomService.Delete(id);
            return Ok();
        }
    }
}