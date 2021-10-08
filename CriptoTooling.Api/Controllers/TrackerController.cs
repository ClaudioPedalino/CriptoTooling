using CriptoTooling.Api.Interfaces;
using CriptoTooling.Api.RequestObjects;
using CriptoTooling.Api.ResponseObjects;
using CriptoTooling.Api.Services.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CriptoTooling.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackerController : ControllerBase
    {
        private readonly ILogger<TrackerController> _logger;
        private readonly ITrackerService _trackerService;

        public TrackerController(ILogger<TrackerController> logger, ITrackerService trackerService)
        {
            _logger = logger;
            _trackerService = trackerService;
        }

        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ConinStatResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetData([FromQuery] CoinStatRequest request)
        {
            var response = await _trackerService.GetData(request);
            return Ok(response);
        }

        [HttpGet("gainers-losers")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(CoinMarketCapResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetGainersLosers([FromQuery] CoinMarketCapRequest request)
        {
            var response = await _trackerService.GetGainersLosers(request);
            return Ok(response);
        }
    }
}
