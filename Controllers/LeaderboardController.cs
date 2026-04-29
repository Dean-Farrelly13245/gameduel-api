using Microsoft.AspNetCore.Mvc;
using GameDuel.API.Data;

namespace GameDuel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly GameDuelContext _context;

        public LeaderboardController(GameDuelContext context)
        {
            _context = context;
        }

        // GET /api/Leaderboard
        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            var games = _context.Games
                .OrderByDescending(g => g.Wins)
                .ThenBy(g => g.Title)
                .ToList();

            return Ok(games);
        }
    }
}