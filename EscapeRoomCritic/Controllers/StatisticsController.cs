using EscapeRoomCritic.Core.DTOs.Statistics;
using EscapeRoomCritic.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoomCritic.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("CityStatistics/{city}")]
        public ActionResult<CityStatisticsDto> GetCityStatistics(string city)
        {
            var result = _statisticsService.GetForCityEscapeRoomsStatistics(city);
            return Ok(result);
        }

        [HttpGet("UserStatistics/{id}")]
        public ActionResult<UserStatisticsDto> GetUserStatistics(int id)
        {
            var result = _statisticsService.GetForUserStatistics(id);
            return Ok(result);
        }

        [HttpGet("EscapeRoomStatistics/{id}")]
        public ActionResult<UserStatisticsDto> GerEscapeRoomStatistics(int id)
        {
            var result = _statisticsService.GetForEscapeRoomStatistics(id);
            return Ok(result);
        }
    }
}