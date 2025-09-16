using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squadra.DTOs;
using Squadra.Services;
using System.Security.Claims;

namespace Squadra.Controllers
{
    [Route("api/matches")]
    [ApiController]
    [Authorize]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IParticipationService _participationService;
        private readonly IMessageService _messageService;
        private readonly IRatingService _ratingService;

        public MatchesController(IMatchService matchService, IParticipationService participationService, IMessageService messageService, IRatingService ratingService)
        {
            _matchService = matchService;
            _participationService = participationService;
            _messageService = messageService;
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatchCreateDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var match = await _matchService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = match.Id }, match);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string sport = null, [FromQuery] string ville = null, [FromQuery] DateTime? date = null)
        {
            var matches = await _matchService.GetAllAsync(sport, ville, date);
            return Ok(matches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var match = await _matchService.GetByIdAsync(id);
                return Ok(match);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{id}/join")]
        public async Task<IActionResult> Join(int id, [FromBody] JoinRequestDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var participation = await _participationService.JoinAsync(id, userId, dto);
            return Ok(participation);
        }

        [HttpGet("{id}/requests")]
        public async Task<IActionResult> GetRequests(int id)
        {
            var requests = await _participationService.GetRequestsAsync(id);
            return Ok(requests);
        }

        [HttpPost("{id}/requests/{requestId}/accept")]
        public async Task<IActionResult> AcceptRequest(int id, int requestId)
        {
            var organizerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _participationService.AcceptAsync(id, requestId, organizerId);
            return NoContent();
        }

        [HttpPost("{id}/requests/{requestId}/reject")]
        public async Task<IActionResult> RejectRequest(int id, int requestId)
        {
            var organizerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _participationService.RejectAsync(id, requestId, organizerId);
            return NoContent();
        }

        [HttpGet("{id}/chat")]
        public async Task<IActionResult> GetChat(int id)
        {
            var messages = await _messageService.GetByMatchIdAsync(id);
            return Ok(messages);
        }

        [HttpPost("{id}/chat")]
        public async Task<IActionResult> SendMessage(int id, [FromBody] MessageCreateDto dto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var message = await _messageService.SendAsync(id, userId, dto);
            return Ok(message);
        }

        [HttpPost("{id}/rate")]
        public async Task<IActionResult> Rate(int id, [FromBody] RatingCreateDto dto)
        {
            var reviewerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var rating = await _ratingService.CreateAsync(id, reviewerId, dto);
            return Ok(rating);
        }

        [HttpGet("{id}/ratings")]
        public async Task<IActionResult> GetRatings(int id)
        {
            var ratings = await _ratingService.GetByMatchIdAsync(id);
            return Ok(ratings);
        }
    }
}