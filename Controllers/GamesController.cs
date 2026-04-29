using Microsoft.AspNetCore.Mvc;
using GameDuel.API.Data;
using GameDuel.API.Models;

namespace GameDuel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameDuelContext _context;

        public GamesController(GameDuelContext context)
        {
            _context = context;
        }

        // GET /api/Games
        [HttpGet]
        public IActionResult GetAll()
        {
            var games = _context.Games.ToList();
            return Ok(games);
        }

        // GET /api/Games/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        // POST /api/Games
        [HttpPost]
        public IActionResult Create(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        // PUT /api/Games/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Game game)
        {
            if (id != game.Id)
                return BadRequest();

            var existing = _context.Games.Find(id);
            if (existing == null)
                return NotFound();

            existing.Title = game.Title;
            existing.Genre = game.Genre;
            existing.Platform = game.Platform;
            existing.ReleaseYear = game.ReleaseYear;
            existing.CoverImageUrl = game.CoverImageUrl;
            existing.Description = game.Description;
            existing.Wins = game.Wins;
            existing.Losses = game.Losses;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE /api/Games/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
                return NotFound();
            _context.Games.Remove(game);
            _context.SaveChanges();
            return NoContent();
        }
    }
}