using Microsoft.AspNetCore.Mvc;
using GameDuel.API.Data;
using GameDuel.API.Models;

namespace GameDuel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchupsController : ControllerBase
    {
        private readonly GameDuelContext _context;

        public MatchupsController(GameDuelContext context)
        {
            _context = context;
        }

        // GET /api/Matchups
        [HttpGet]
        public IActionResult GetAll()
        {
            var matchups = _context.Matchups.ToList();
            return Ok(matchups);
        }

        // GET /api/Matchups/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var matchup = _context.Matchups.Find(id);
            if (matchup == null)
                return NotFound();

            return Ok(matchup);
        }

        // POST /api/Matchups
        [HttpPost]
        public IActionResult Create([FromBody] Matchup matchup)
        {
            matchup.CreatedAt = DateTime.UtcNow;
            matchup.VotedAt = null;
            matchup.WinnerId = null;

            _context.Matchups.Add(matchup);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = matchup.Id }, matchup);
        }

        // PUT /api/Matchups/5/vote
        [HttpPut("{id}/vote")]
        public IActionResult Vote(int id, int winnerId)
        {
            var matchup = _context.Matchups.Find(id);
            if (matchup == null)
                return NotFound();

            matchup.WinnerId = winnerId;
            matchup.VotedAt = DateTime.UtcNow;

            var winner = _context.Games.Find(winnerId);
            var loserId = matchup.GameAId == winnerId ? matchup.GameBId : matchup.GameAId;
            var loser = _context.Games.Find(loserId);

            if (winner != null) winner.Wins++;
            if (loser != null) loser.Losses++;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE /api/Matchups/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var matchup = _context.Matchups.Find(id);
            if (matchup == null)
                return NotFound();

            _context.Matchups.Remove(matchup);
            _context.SaveChanges();
            return NoContent();
        }
    }
}