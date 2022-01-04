using Developer_Test_GICREPS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog.Fluent;
using System.Globalization;

namespace Developer_Test_GICREPS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GicController : ControllerBase
    {
        private readonly IGicService _gicService;
        private readonly ILogger<GicController> _logger;

        public GicController(ILogger<GicController> logger, IGicService gicService)
        {
            _logger = logger;
            _gicService = gicService;
        }
       

        [HttpGet]
        [Route("population")]
        public async Task<IActionResult> GetPopulation([FromQuery] GetDataQuery query)
        {
            try
            {
                string jsonStates = JsonConvert.SerializeObject(query.States);
                jsonStates = jsonStates[1..^1];
                var currentDate = DateTime.Now;
                var currentDateString = currentDate.ToString("yyyy-MM-dd HH:m:s.ff",
                                CultureInfo.InvariantCulture);

                _logger.LogInformation($"{currentDateString} – API endpoint called- /households?state={jsonStates}");
                var data = await _gicService.GetGicData("population", query.States);
                if (data != null) return Ok(data);
                return StatusCode(404);
            } catch(Exception ex)
            {
                _logger.LogError($"API error: {DateTime.Now} - {ex.Message} \n {ex.StackTrace}");
                return null;
            }
            
        }
        [HttpGet]
        [Route("household")]
        public async Task<IActionResult> GetHouseHold([FromQuery] GetDataQuery query)
        {
            try
            {
                string jsonStates = JsonConvert.SerializeObject(query.States);
                jsonStates = jsonStates[1..^1];
                var currentDate = DateTime.Now;
                var currentDateString = currentDate.ToString("yyyy-MM-dd HH:m:s.ff",
                                CultureInfo.InvariantCulture);

                _logger.LogInformation($"{currentDateString} – API endpoint called- /households?state={jsonStates}");
                var data = await _gicService.GetGicData("household", query.States);
                if (data != null) return Ok(data);
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                _logger.LogError($"API error: {DateTime.Now} - {ex.Message} \n {ex.StackTrace}");
                return null;
            }
        }
    }
}
