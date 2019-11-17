using EscapeRoomCritic.Core.DTOs.Identity;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoomCritic.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthorizationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        /// <summary>
        /// Authenticate endpoint to get token
        /// </summary>
        /// <response code="200">Returns token</response>
        /// <response code="400">Validation or bad value error</response>
        /// <response code="401">Authentication error</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [AllowAnonymous]
        [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] Credentials credentials)
        {
            var user = _identityService.Authenticate(credentials.Username, credentials.Password);
            return Ok(user);
        }
    }
}
