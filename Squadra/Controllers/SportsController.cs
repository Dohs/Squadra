using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squadra.Services;

namespace Squadra.Controllers
{
    [Route("api/sports")]
    [ApiController]
    [Authorize]
    public class SportsController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportsController(ISportService sportService)
        {
            _sportService = sportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sports = await _sportService.GetAllAsync();
            return Ok(sports);
        }
    }
}