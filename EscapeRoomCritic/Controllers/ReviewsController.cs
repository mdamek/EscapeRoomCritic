using EscapeRoomCritic.Core.DTOs.Reviews;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoomCritic.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Get all reviews of escape room
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        [HttpGet("byEscapeRoom/{id}")]
        public ActionResult<ReviewDto> GetByEscapeRoom(int id)
        {
            return Ok(_reviewService.GetByRoomId(id));
        }

        /// <summary>
        /// Get all reviews created by one user
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        [HttpGet("byUser/{id}")]
        public ActionResult<ReviewDto> GetByUser(int id)
        {
            return Ok(_reviewService.GetByUserId(id));
        }

        /// <summary>
        /// Add review to escape room
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authorization error - access denied</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = Role.Visitor + ", " + Role.Admin)]
        [HttpPost]
        public ActionResult Post([FromBody] NewReviewDto value)
        {
            _reviewService.Add(value);
            return Ok();
        }

        /// <summary>
        /// Delete review of escape room
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
            _reviewService.Delete(id);
            return Ok();
        }
    }
}